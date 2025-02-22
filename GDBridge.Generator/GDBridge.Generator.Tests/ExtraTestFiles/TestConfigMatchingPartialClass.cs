using GDBridge;
using Godot;

public partial class ConfigTestBridge : GDScriptBridge
{
    public const string GDClassName = "ConfigTest";
    public Variant snake_case_variable
    {
        get => GdObject.Get("snake_case_variable");
        set => GdObject.Set("snake_case_variable", Godot.Variant.From(value));
    }

    public Variant property_var
    {
        get => GdObject.Get("property_var");
        set => GdObject.Set("property_var", Godot.Variant.From(value));
    }

    public ConfigTestBridge(GodotObject gdObject) : base(gdObject) { }

    public Variant snake_case_function() => GdObject.Call("snake_case_function");

    public Variant get_property_var_compat() => GdObject.Call("get_property_var");
}