using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GDParser;
using Microsoft.CodeAnalysis;
using SourceGeneratorUtils;
using System.Text.Json;
using System.Diagnostics;

namespace GDBridge.Generator;

[Generator]
public class GDBridgeIncrementalSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var scriptSources = context.AdditionalTextsProvider
            .Where(t => t.Path.EndsWith(".gd"))
            .Select((t, ct) => t.GetText(ct)?.ToString()!)
            .Where(t => t is not null)
            .Collect();

        var configuration = context.AdditionalTextsProvider
            .Where(t => t.Path.EndsWith("GDBridgeConfiguration.json"))
            .Select((t, ct) => t.GetText(ct)?.ToString()!)
            .Where(t => t is not null)
            .Collect();

        IncrementalValueProvider<((ImmutableArray<string> scripts, Compilation compilation) scriptAndCompilation, ImmutableArray<string> configuration)> providers = scriptSources
            .Combine(context.CompilationProvider)
            .Combine(configuration);

        context.RegisterSourceOutput(providers, (c, p) => Generate(c, p.scriptAndCompilation.compilation, p.scriptAndCompilation.scripts, p.configuration));
    }

    static void Generate(SourceProductionContext context, Compilation compilation, ImmutableArray<string> scripts, ImmutableArray<string> configurations)
    {
        var configuration = ReadConfiguration(configurations.FirstOrDefault());

        var availableTypes = GetAvailableTypes(compilation);

        var gdClasses = scripts
            .Select(ClassParser.Parse)
            .Where(c => c is not null && c?.ClassName is not null);
        
        foreach (var gdClass in gdClasses)
        {
            var className = gdClass!.ClassName!;
            if (configuration.AppendBridgeToClassNames) className = $"{className}Bridge";

            var existingMatchingPartialClass = availableTypes.SingleOrDefault(t => t.Name == className);
            var existingNamespace = existingMatchingPartialClass?.Namespace;
            
            if(configuration.GenerateOnlyForMatchingBridgeClass && existingMatchingPartialClass is null)
                continue;
            
            if (existingNamespace is null && !string.IsNullOrWhiteSpace(configuration.DefaultBridgeNamespace))
                existingNamespace = configuration.DefaultBridgeNamespace;
            
            var source = GenerateClass(gdClass, className, availableTypes, configuration, existingNamespace);

            context.AddSource(className, source);
        }
    }
    
    static List<AvailableType> GetAvailableTypes(Compilation compilation)
    {
        var godotAssembly = compilation.SourceModule.ReferencedAssemblySymbols
            .FirstOrDefault(e => e.Name == "GodotSharp");

        var availableGodotTypes = new List<AvailableType>();

        if (godotAssembly is not null)
            availableGodotTypes = godotAssembly.GlobalNamespace
                .GetNamespaceMembers().First(n => n.Name == "Godot")
                .GetMembers()
                .Where(m => m.IsType)
                .Select(m => new AvailableType(m.Name, "Godot"))
                .ToList();

        var availableTypes = compilation.Assembly.TypeNames
            .Select(tn => new AvailableType(tn, ResolveNamespace(compilation.GetSymbolsWithName(tn, SymbolFilter.Type).Where(x => x.ContainingType is null).SingleOrDefault()?.ContainingNamespace)))
            .Where(x => x.Namespace is not null)
            .ToList()
            .Concat(availableGodotTypes)
            .ToList();

        return availableTypes;
    }
    static Configuration ReadConfiguration(string? configurationFile)
    {
        Configuration? configuration = null;

        if (configurationFile is not null)
        {
            try
            {
                configuration = JsonSerializer.Deserialize<Configuration>(configurationFile);
            }
            catch (Exception)
            {
                // ignored
            }
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

    static string GenerateClass(GdClass gdClass, string className, ICollection<AvailableType> availableTypes, Configuration configuration, string? existingNamespace = null)
    {
        var source = new SourceWriter();
        var bridgeWriter = new BridgeWriter(availableTypes, source, configuration);

        if (!string.IsNullOrWhiteSpace(existingNamespace))
            source
                .WriteLine($"namespace {existingNamespace}")
                .OpenBlock();
        
        source
            .WriteLine(
                $"""
                 using GDBridge;
                 using Godot;

                 public partial class {className} : GDScriptBridge
                 """)
            .OpenBlock();
        
        source.WriteLine($"public {className}(GodotObject gdObject) : base(gdObject) {{}}").WriteEmptyLines(1);
        source.WriteLine($"""public const string GDClassName = "{gdClass.ClassName}";""").WriteEmptyLines(1);
        
        bridgeWriter.Properties(gdClass.Variables);
        bridgeWriter.Methods(gdClass.Functions, gdClass.Variables);
        bridgeWriter.Signals(gdClass.Signals);

        bridgeWriter.PropertyNameInnerClass(gdClass.Variables).WriteEmptyLines(1);
        bridgeWriter.MethodNameInnerClass(gdClass.Functions).WriteEmptyLines(1);
        bridgeWriter.SignalNameInnerClass(gdClass.Signals);

        source.CloseAllBlocks();

        return source.ToString();
    }
}