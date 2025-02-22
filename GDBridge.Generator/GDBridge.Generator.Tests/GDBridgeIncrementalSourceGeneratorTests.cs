using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Godot;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using VerifyTests;
using Xunit;
using static VerifyXunit.Verifier;

namespace GDBridge.Generator.Tests;

public class GDBridgeIncrementalSourceGeneratorTests
{
    static GDBridgeIncrementalSourceGeneratorTests() => VerifySourceGenerators.Initialize();

    const string ConfigTestPath = "./ConfigTest.gd";
    const string ConfigTestScript =
        """
        class_name ConfigTest

        var snake_case_variable;
        var property_var;

        func snake_case_function()
            pass
        
        func get_property_var()
            pass
        """;

    public static TheoryData<string> GetFiles()
    {
        var data = new TheoryData<string>();

        var scriptPaths = Directory.GetFiles("./TestScripts")
            .Where(f => f.EndsWith(".gd"))
            .ToList();

        foreach (var path in scriptPaths)
        {
            data.Add(path);
        }

        return data;
    }

    [Theory]
    [MemberData(nameof(GetFiles))]
    public Task AllNoConfig(string path)
    {
        var driver = GeneratorDriver(path, File.ReadAllText(path));

        var setting = new VerifySettings();
        setting.UseFileName(Path.GetFileName(path));
        setting.UseDirectory("Verified/AllNoConfig");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UsePascalCaseConfig()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { UsePascalCase = true });

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UsePascalCaseConfig));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }
    
    [Fact]
    public Task DontUsePascalCaseConfig()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { UsePascalCase = false });

        var setting = new VerifySettings();
        setting.UseFileName(nameof(DontUsePascalCaseConfig));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }
    
    [Fact]
    public Task UseGenerateOnlyForMatchingBridgeClassConfigWithMatchingClass()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { GenerateOnlyForMatchingBridgeClass = true }, true);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseGenerateOnlyForMatchingBridgeClassConfigWithMatchingClass));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UseGenerateOnlyForMatchingBridgeClassConfigWithNoMatchingClass()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { GenerateOnlyForMatchingBridgeClass = true }, false);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseGenerateOnlyForMatchingBridgeClassConfigWithNoMatchingClass));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UseAppendBridgeToClassNames()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { AppendBridgeToClassNames = true });

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseAppendBridgeToClassNames));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    [Fact]
    public Task DontUseAppendBridgeToClassNames()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { AppendBridgeToClassNames = false });

        var setting = new VerifySettings();
        setting.UseFileName(nameof(DontUseAppendBridgeToClassNames));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UseDefaultBridgeNamespaceWithNoMatchingClass()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { DefaultBridgeNamespace = "Bridge" });

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseDefaultBridgeNamespaceWithNoMatchingClass));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UseDefaultBridgeNamespaceWithMatchingClass()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, new() { DefaultBridgeNamespace = "Bridge" }, true);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseDefaultBridgeNamespaceWithMatchingClass));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    static GeneratorDriver GeneratorDriver(string path, string script, Configuration? configuration = null, bool addMatchingConfigCSharpClass = false)
    {
        var testCodePaths = Directory.GetFiles("./TestProjectClasses")
            .Where(f => f.EndsWith(".cs"))
            .ToList();
        var compilation = CSharpCompilation.Create("Test")
            .AddReferences(MetadataReference.CreateFromFile(typeof(Node).Assembly.Location));// Will throw an exception if a breakpoint is hit when debugging

        if(addMatchingConfigCSharpClass)
            testCodePaths.Add("./ExtraTestFiles/TestConfigMatchingPartialClass.cs");
        
        foreach (var testCodePath in testCodePaths)
        {
            compilation = compilation.AddSyntaxTrees(CSharpSyntaxTree.ParseText(File.ReadAllText(testCodePath)));
        }
        
        var generator = new GDBridgeIncrementalSourceGenerator();

        var additionalTexts = new List<AdditionalText>
        {
            new SimpleAdditionalText(path, script)
        };
        
        if(configuration is not null)
            additionalTexts.Add(CreateConfigurationFile(configuration));
        
        var driver = CSharpGeneratorDriver.Create(generator)
            .AddAdditionalTexts(additionalTexts.ToImmutableArray());

        return driver.RunGenerators(compilation);
    }

    static AdditionalText CreateConfigurationFile(Configuration configuration)
    {
        var json = JsonSerializer.Serialize(configuration);
        return new SimpleAdditionalText("./GDBridgeConfiguration.json", json);
    }
}