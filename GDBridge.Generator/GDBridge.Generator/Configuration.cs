namespace GDBridge.Generator;

public class Configuration
{
    public bool UsePascalCase { get; set; }
    public bool GenerateOnlyForMatchingBridgeClass { get; set; }
    public string? DefaultBridgeNamespace { get; set; }
    public bool AppendBridgeToClassNames { get; set; } = true;
}