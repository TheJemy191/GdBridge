using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using GDParser;
using Microsoft.CodeAnalysis.CSharp;
using SourceGeneratorUtils;

namespace GDBridge.Generator;

class BridgeWriter
{
    readonly ICollection<AvailableType> availableTypes;
    readonly SourceWriter source;
    readonly Configuration configuration;
    public BridgeWriter(ICollection<AvailableType> availableTypes, SourceWriter source, Configuration configuration)
    {
        this.availableTypes = availableTypes;
        this.source = source;
        this.configuration = configuration;
    }

    public SourceWriter Variables(ReadOnlyCollection<GdVariable> variables)
    {
        foreach (var variable in variables)
        {
            if (variable.Name.StartsWith("_"))
                continue;

            source.WriteLine($"public {variable.Type.ToCSharpTypeString(availableTypes)} {Pascalize(variable.Name)}")
                .OpenBlock()
                .WriteLine(
                    $"""
                     get => GdObject.Get("{variable.Name}"){GetTypeCast(variable.Type)};
                     set => GdObject.Set("{variable.Name}", Godot.Variant.From(value));
                     """)
                .CloseBlock()
                .WriteEmptyLines(1);
        }

        return source;
    }

    public SourceWriter Functions(IEnumerable<GdFunction> functions, ReadOnlyCollection<GdVariable> variables)
    {
        var scriptFunctions = new List<GdFunction>();

        // Iterate over functions with default parameters omitted
        foreach (var function in functions)
        {
            // Filter out functions which start with an underscore to avoid native function overrides
            if (function.Name.StartsWith("_"))
            {
                continue;
            }

            var defaultParams = function.Parameters.Where(p => p.Name.Contains('=')).ToList();
            if (!defaultParams.Any())
            {
                scriptFunctions.Add(function);
                continue;
            }
            var nonDefaults = function.Parameters.Where(p => !defaultParams.Contains(p)).ToList();

            // Add a new function for each parameter signature
            for (var i = 0; i <= defaultParams.Count; i++)
            {
                var @params = new List<GdVariable>(nonDefaults);
                @params.AddRange(defaultParams.Take(i));
                scriptFunctions.Add(new GdFunction(function.Name, new ReadOnlyCollection<GdVariable>(@params),
                    function.ReturnType));
            }
        }

        foreach (var function in scriptFunctions)
        {
            var returnString = function.ReturnType.ToCSharpTypeString(availableTypes);
            
            var funcName = Pascalize(function.Name);

            var funcNameStart = function.Name.Substring(0, 4);
            var funcNameEnd = function.Name.Substring(4);
            if (!configuration.UsePascalCase && variables.Any(v => v.Name == funcNameEnd) && funcNameStart is "get_" or "set_")
                funcName += "_compat";
            
            var parameters = InParameters(function.Parameters);
            var gdParameters = CallParameters(function.Parameters);
            var typeCast = GetTypeCast(function.ReturnType);
            
            source.WriteEmptyLines(1)
                .WriteLine(
                    $"""public {returnString} {funcName}({parameters}) => GdObject.Call("{function.Name}"{gdParameters}){typeCast};""");
        }

        return source;
    }
    string InParameters(IEnumerable<GdVariable> parameters) => string.Join(", ", parameters.Select(InParameter));
    string InParameter(GdVariable parameter) => $"{parameter.Type.ToCSharpTypeString(availableTypes)} {Pascalize(SanitizeParameter(parameter.Name))}";
    string Pascalize(string text) => configuration.UsePascalCase ? Regex.Replace(text, "(?:^|_| +)(.)", match => match.Groups[1].Value.ToUpper()) : text;

    string SanitizeParameter(string parameter)
    {
        // Return parameter if it's already valid
        if (SyntaxFacts.GetKeywordKind(parameter) == SyntaxKind.None && SyntaxFacts.IsValidIdentifier(parameter))
        {
            return parameter;
        }

        // Remove default parameter values
        var param = parameter;
        if (parameter.Contains('='))
        {
            param = parameter.Substring(0, parameter.IndexOf('=')).Trim();
        }

        // Validate it's not a reserved keyword
        return SyntaxFacts.GetKeywordKind(param) == SyntaxKind.None && SyntaxFacts.IsValidIdentifier(param) ? param : $"@{param}";
    }

    string CallParameters(IEnumerable<GdVariable> parameters)
    {
        parameters = parameters.ToList();
        if (!parameters.Any())
            return "";
        return $", {string.Join(", ", parameters.Select(p => Pascalize(SanitizeParameter(p.Name))))}";
    }

    string GetTypeCast(GdType type)
    {
        var typeString = type.ToCSharpTypeString(availableTypes);
        if (typeString is "Variant" or "void")
            return "";

        return $".As<{typeString}>()";
    }


}