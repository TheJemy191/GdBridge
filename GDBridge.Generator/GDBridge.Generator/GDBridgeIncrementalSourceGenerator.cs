using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GDParser;
using Microsoft.CodeAnalysis;
using SourceGeneratorUtils;
using System.Text.Json;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace GDBridge.Generator;

[Generator]
public class GDBridgeIncrementalSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var scriptSources = context.AdditionalTextsProvider
            .Where(t => t.Path.EndsWith(".gd"))
            .Select((t, ct) => (t.Path, t.GetText(ct)?.ToString()!))
            .Where(t => t.Item2 is not null)
            .Collect();

        var configuration = context.AdditionalTextsProvider
            .Where(t => t.Path.EndsWith("GDBridgeConfiguration.json"))
            .Select((t, ct) => t.GetText(ct)?.ToString()!)
            .Where(t => t is not null)
            .Collect();

        IncrementalValueProvider<((ImmutableArray<(string Path, string Text)> scripts, Compilation compilation) scriptAndCompilation, ImmutableArray<string> configuration)> providers = scriptSources
            .Combine(context.CompilationProvider)
            .Combine(configuration);

        context.RegisterSourceOutput(providers, (c, p) => Generate(c, p.scriptAndCompilation.compilation, p.scriptAndCompilation.scripts, p.configuration));
    }

    static void Generate(SourceProductionContext context, Compilation compilation, ImmutableArray<(string Path, string Text)> scripts, ImmutableArray<string> configurations)
    {
        var configuration = ReadConfiguration(configurations.FirstOrDefault());

        var availableTypes = GetAvailableTypes(compilation);

        var gdClasses = scripts
            .Select(x => (x.Path, ClassParser.Parse(x.Text)))
            .Where(x => x.Item2 is not null && x.Item2?.ClassName is not null);
        
        List<(string TypeString, GdBuiltInType BuiltInType, string CSharpTypeString)> usedBaseTypes = [ ("GodotObject", GdBuiltInType.Object, "Godot.GodotObject") ];
        
        foreach (var (scriptPath, gdClass) in gdClasses)
        {
            var className = gdClass!.ClassName!;
            if (configuration.AppendBridgeToClassNames) className = $"{className}Bridge";

            var existingMatchingPartialClass = availableTypes.SingleOrDefault(t => t.Name == className);
            var existingNamespace = existingMatchingPartialClass?.Namespace;
            
            if(configuration.GenerateOnlyForMatchingBridgeClass && existingMatchingPartialClass is null)
                continue;
            
            if (existingNamespace is null && !string.IsNullOrWhiteSpace(configuration.DefaultBridgeNamespace))
                existingNamespace = configuration.DefaultBridgeNamespace;

            (string baseClassTypeName, string nativeTypeName, bool isGodotType, IEnumerable<GdClass> inheritedGdClasses) GetBaseClass(GdClass _gdClass) {
                (string TypeString, GdBuiltInType BuiltInType, string CSharpTypeString) baseType
                    = (_gdClass.Extend?.TypeString ?? "Object", _gdClass.Extend?.BuiltInType ?? GdBuiltInType.Object, _gdClass.Extend?.ToCSharpTypeString(availableTypes) ?? "Godot.GodotObject");
                if (!usedBaseTypes.Any(x => (_gdClass.Extend?.IsBuiltIn ?? true && x.BuiltInType == baseType.BuiltInType) || (x.TypeString == baseType.TypeString)))
                    usedBaseTypes.Add(baseType);
                
                var godotBaseClass = availableTypes.SingleOrDefault(x => (x.Name == baseType.TypeString || (baseType.TypeString == "Object" && x.Name == "GodotObject")) && x.Namespace == "Godot");
                if (godotBaseClass is not null)
                    return ($"global::GDBridge.{godotBaseClass.Name}Proxy", $"global::Godot.{godotBaseClass.Name}", true, []);
                
                var baseClassName = baseType.TypeString;
                if (configuration.AppendBridgeToClassNames) baseClassName = $"{baseType.TypeString}Bridge";
                
                var existingMatchingPartialBaseClass = availableTypes.SingleOrDefault(t => t.Name == className);
                var baseNamespace = existingMatchingPartialClass?.Namespace;
                
                if (baseNamespace is null && !string.IsNullOrWhiteSpace(configuration.DefaultBridgeNamespace))
                    baseNamespace = configuration.DefaultBridgeNamespace;
                
                var baseClass = gdClasses.SingleOrDefault(x => x.Item2?.ClassName == baseType.TypeString).Item2;
                if (baseClass is null)
                    return ("INVALID", "INVALID", false, []);

                var (_, nativeTypeName, _, inheritedGdClasses) = GetBaseClass(baseClass);
                var inherited = inheritedGdClasses.ToList();
                inherited.Add(baseClass);

                return ($"global::{baseNamespace}{(!string.IsNullOrWhiteSpace(baseNamespace) ? "." : "")}{baseClassName}", nativeTypeName, false, inherited);
            }
            
            var (baseClassTypeName, nativeTypeName, baseIsGodotType, inheritedGdClasses) = GetBaseClass(gdClass);
            var source = GenerateClass(gdClass, className, scriptPath, baseClassTypeName, nativeTypeName, baseIsGodotType, inheritedGdClasses, availableTypes, configuration, existingNamespace);
            context.AddSource(className, source);
        }
        
        var godotTypes = compilation.SourceModule.ReferencedAssemblySymbols.FirstOrDefault(e => e.Name == "GodotSharp")?.GlobalNamespace?.GetNamespaceMembers()?.First(n => n.Name == "Godot")?.GetMembers().Where(m => m.IsType);

        foreach (var (typeString, builtInType, cSharpTypeString) in usedBaseTypes)
        {
            var godotType = godotTypes.SingleOrDefault(x => ($"Godot.{x.Name}" == cSharpTypeString && x.Name != "Variant") || (builtInType == GdBuiltInType.Object && x.Name == "Godot.GodotObject")) as ITypeSymbol;
            if (godotType is null)
                continue;

            var proxyName = $"{typeString}Proxy";

            var source = new SourceWriter();

            source.WriteLine("#nullable enable");
            source.WriteLine("namespace GDBridge").OpenBlock();

            source.WriteLine($"""/// <inheritdoc cref="global::Godot.{typeString}"/>""");
            source.WriteLine($"public abstract class {proxyName}").OpenBlock();
            
            // This is public because there are instances such as having to down-cast it where the user needs access to the inner object
            source.WriteLine($"public global::Godot.{typeString}? InnerObject {{ get; private set; }}");
            source.WriteLine($"protected {proxyName}(global::Godot.{typeString}? innerObject) => InnerObject = innerObject;").WriteEmptyLines(1);

            List<(ISymbol Symbol, ITypeSymbol OwningType)> publicMembers = [];
            var tempType = godotType;
            while (tempType?.BaseType is not null) {
                publicMembers.AddRange(tempType.GetMembers().Where(x => x.DeclaredAccessibility == Accessibility.Public && x.CanBeReferencedByName && !x.IsAbstract && !x.IsStatic && x.Name.First() != '_').Select(x => (x, tempType)));
                tempType = tempType.BaseType;
            }

            foreach (var (property, owningType) in publicMembers.Where(x => x.Symbol.Kind == SymbolKind.Property).Select(x => (x.Symbol as IPropertySymbol, x.OwningType)))
            {
                if (property is null)
                    return;
                
                var obsoleteAttribute = property.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "ObsoleteAttribute");
                
                if (obsoleteAttribute is not null)
                    source.WriteLine("#pragma warning disable 0618");

                source.WriteLine($"""/// <inheritdoc cref="global::Godot.{owningType}.{property.Name}"/>""");

                if (obsoleteAttribute is not null)
                    source.WriteLine($"[System.Obsolete({string.Join(", ", obsoleteAttribute.ConstructorArguments.Select(x => $"\"{x.Value}\""))})]");

                source.WriteLine($"public {property.Type} {property.Name}")
                    .OpenBlock();

                if (property.GetMethod is not null)
                    source.WriteLine($"get")
                    .OpenBlock()
                    .WriteLine($"if (InnerObject is null) throw new System.NullReferenceException();")
                    .WriteLine($"return InnerObject.{property.Name};")
                    .CloseBlock();
                
                if (property.SetMethod is not null)
                    source.WriteLine($"set")
                    .OpenBlock()
                    .WriteLine($"if (InnerObject is null) throw new System.NullReferenceException();")
                    .WriteLine($"InnerObject.{property.Name} = value;")
                    .CloseBlock();
                
                source.CloseBlock();
                
                if (obsoleteAttribute is not null)
                    source.WriteLine("#pragma warning restore 0618");

                source.WriteEmptyLines(1);
            }

            foreach (var (@event, owningType) in publicMembers.Where(x => x.Symbol.Kind == SymbolKind.Event).Select(x => (x.Symbol as IEventSymbol, x.OwningType)))
            {
                if (@event is null)
                    return;
                
                var obsoleteAttribute = @event.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "ObsoleteAttribute");
                
                if (obsoleteAttribute is not null)
                    source.WriteLine("#pragma warning disable 0618");
                
                source.WriteLine($"""/// <inheritdoc cref="global::Godot.{owningType}.{@event.Name}"/>""");

                if (obsoleteAttribute is not null)
                    source.WriteLine($"[System.Obsolete({string.Join(", ", obsoleteAttribute.ConstructorArguments.Select(x => $"\"{x.Value}\""))})]");

                source.WriteLine($"public event {@event.Type} {@event.Name}")
                    .OpenBlock();
                
                if (@event.AddMethod is not null)
                    source.WriteLine($"add")
                    .OpenBlock()
                    .WriteLine($"if (InnerObject is null) throw new System.NullReferenceException();")
                    .WriteLine($"InnerObject.{@event.Name} += value;")
                    .CloseBlock();
                
                if (@event.RemoveMethod is not null)
                    source.WriteLine($"remove")
                    .OpenBlock()
                    .WriteLine($"if (InnerObject is null) throw new System.NullReferenceException();")
                    .WriteLine($"InnerObject.{@event.Name} -= value;")
                    .CloseBlock();
                
                source.CloseBlock();
                
                if (obsoleteAttribute is not null)
                    source.WriteLine("#pragma warning restore 0618");
                
                source.WriteEmptyLines(1);
            }

            foreach (var (method, owningType) in publicMembers.Where(x => x.Symbol.Kind == SymbolKind.Method).Select(x => (x.Symbol as IMethodSymbol, x.OwningType)))
            {
                if (method is null || method.MethodKind != MethodKind.Ordinary)
                    continue;
                
                var obsoleteAttribute = method.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "ObsoleteAttribute");
                
                if (obsoleteAttribute is not null)
                    source.WriteLine("#pragma warning disable 0618");

                source.WriteLine($"""/// <inheritdoc cref="global::Godot.{owningType}.{method.Name}"/>""");

                if (obsoleteAttribute is not null)
                    source.WriteLine($"[System.Obsolete({string.Join(", ", obsoleteAttribute.ConstructorArguments.Select(x => $"\"{x.Value}\""))})]");
                
                var genericParameters = !method.TypeParameters.IsEmpty ? $"<{string.Join(", ", method.TypeParameters)}>" : "";
                var whereStatements = string.Join("", method.TypeParameters.Select(x => $" where {x.Name} : class"));

                source.WriteLine($"public {(method.Name == "ToString" ? "override " : "")}{method.ReturnType} {method.Name}{genericParameters}({string.Join(", ", method.Parameters)}){whereStatements}")
                    .OpenBlock()
                    .WriteLine($"if (InnerObject is null) throw new System.NullReferenceException();")
                    .WriteLine($"{(method.ReturnType.SpecialType != SpecialType.System_Void ? "return " : "")}InnerObject.{method.Name}{genericParameters}({string.Join(", ", method.Parameters.Select(x => $"@{x.Name}"))});")
                    .CloseBlock();

                if (obsoleteAttribute is not null)
                    source.WriteLine("#pragma warning restore 0618");

                source.WriteEmptyLines(1);
            }

            source.WriteEmptyLines(1);

            source.WriteLine($"""/// <inheritdoc cref="global::Godot.{typeString}.PropertyName"/>""")
                .WriteLine($"public class PropertyName : global::Godot.{typeString}.PropertyName")
                .OpenBlock().CloseBlock()
                .WriteEmptyLines(1);
            
            source.WriteLine($"""/// <inheritdoc cref="global::Godot.{typeString}.MethodName"/>""")
                .WriteLine($"public class MethodName : global::Godot.{typeString}.MethodName")
                .OpenBlock().CloseBlock()
                .WriteEmptyLines(1);
            
            source.WriteLine($"""/// <inheritdoc cref="global::Godot.{typeString}.SignalName"/>""")
                .WriteLine($"public class SignalName : global::Godot.{typeString}.SignalName")
                .OpenBlock().CloseBlock()
                .WriteEmptyLines(1);

            source.CloseAllBlocks();

            context.AddSource(proxyName, source.ToString());
        }
    }
    
    static IEnumerable<AvailableType> GetAvailableTypes(Compilation compilation)
    {
        var godotAssembly = compilation.SourceModule.ReferencedAssemblySymbols
            .FirstOrDefault(e => e.Name == "GodotSharp");

        IEnumerable<AvailableType> availableGodotTypes = [];

        if (godotAssembly is not null)
            availableGodotTypes = godotAssembly.GlobalNamespace
                .GetNamespaceMembers().First(n => n.Name == "Godot")
                .GetMembers()
                .Where(m => m.IsType)
                .Select(m => new AvailableType(m.Name, "Godot"));

        var availableTypes = compilation.Assembly.TypeNames
            .Select(tn => new AvailableType(tn, ResolveNamespace(compilation.GetSymbolsWithName(tn, SymbolFilter.Type).Where(x => x.ContainingType is null).SingleOrDefault()?.ContainingNamespace)))
            .Where(x => x.Namespace is not null)
            .Concat(availableGodotTypes);

        return availableTypes;
    }

    static Configuration ReadConfiguration(string? configurationFile)
    {
        Configuration? configuration = null;

        if (configurationFile is not null)
        {
            try { configuration = JsonSerializer.Deserialize<Configuration>(configurationFile); }
            catch (Exception) {} // ignored
        }

        configuration ??= new Configuration();
        return configuration;
    }

    static string ResolveNamespace(INamespaceSymbol? symbol, string childNamespace = "")
    {
        while (symbol is { IsGlobalNamespace: false })
        {
            if (childNamespace == "")
                childNamespace = symbol.Name;
            else
                childNamespace = $"{symbol.Name}.{childNamespace}";

            symbol = symbol.ContainingNamespace;
        }
        return childNamespace;
    }

    static string GenerateClass(GdClass gdClass, string className, string scriptFilename, string baseClassName, string nativeTypeName, bool baseIsGodotType, IEnumerable<GdClass> inheritedGdClasses, IEnumerable<AvailableType> availableTypes, Configuration configuration, string? existingNamespace = null)
    {
        var source = new SourceWriter();
        var bridgeWriter = new BridgeWriter(availableTypes, source, configuration);
        
        source.WriteLine("using GDBridge;").WriteLine("using Godot;").WriteEmptyLines(1);
        source.WriteLine("#nullable enable");

        if (!string.IsNullOrWhiteSpace(existingNamespace))
            source
                .WriteLine($"namespace {existingNamespace}")
                .OpenBlock();
        
        source.WriteLine($"public partial class {className} : {baseClassName}");
        source.OpenBlock();

        source.WriteLine($"""public {(!baseIsGodotType ? "new " : "")}const string GDClassName = "{gdClass.ClassName}";""");
        //source.WriteLine($"""private static readonly global::Godot.GDScript? ScriptResource = global::Godot.ResourceLoader.Load<global::Godot.GDScript>(global::Godot.ProjectSettings.LocalizePath("{Path.GetFullPath(scriptFilename).Replace("\\", "\\\\")}"));""");
        source.WriteEmptyLines(1);
        
        //source.WriteLine($"public {className}() : base(ScriptResource.New()) {{ }}");
        source.WriteLine($"protected {className}({nativeTypeName}? innerObject) : base(innerObject) {{}}").WriteEmptyLines(1);

        source.WriteLine($"public static {(!baseIsGodotType ? "new " : "")}{className} From({nativeTypeName} obj) => new(obj);").WriteEmptyLines(1);

        source.WriteLine($"public static implicit operator {nativeTypeName}?({className} b) => b.InnerObject;").WriteEmptyLines(1);

        var publicProperties = gdClass.Variables.Where(x => x.Name.First() != '_').Where(x => !inheritedGdClasses.Any(c => c.Variables.Any(v => v.Name == x.Name)));
        var publicMethods = gdClass.Functions.Where(x => x.Name.First() != '_').Where(x => !inheritedGdClasses.Any(c => c.Functions.Any(f => f.Name == x.Name)));
        
        bridgeWriter.Properties(publicProperties);
        bridgeWriter.Methods(publicMethods, publicProperties);
        bridgeWriter.Signals(gdClass.Signals);

        bridgeWriter.PropertyNameInnerClass(publicProperties, baseClassName).WriteEmptyLines(1);
        bridgeWriter.MethodNameInnerClass(publicMethods, baseClassName).WriteEmptyLines(1);
        bridgeWriter.SignalNameInnerClass(gdClass.Signals, baseClassName);

        source.CloseAllBlocks();

        return source.ToString();
    }
}