//HintName: ConfigTestBridge.cs
using GDBridge;
using Godot;

public partial class ConfigTestBridge : GDScriptBridge
{
    public ConfigTestBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "ConfigTest";

    public Variant snake_case_variable
    {
        get => GdObject.Get(PropertyName.snake_case_variable);
        set => GdObject.Set(PropertyName.snake_case_variable, Godot.Variant.From(value));
    }

    public Variant property_var
    {
        get => GdObject.Get(PropertyName.property_var);
        set => GdObject.Set(PropertyName.property_var, Godot.Variant.From(value));
    }

    public Variant snake_case_function() => GdObject.Call(MethodName.snake_case_function);

    public Variant get_property_var_compat() => GdObject.Call(MethodName.get_property_var_compat);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'snake_case_variable' property.
        public static readonly StringName snake_case_variable = "snake_case_variable";

        //
        // Summary:
        //     Cached name for the 'property_var' property.
        public static readonly StringName property_var = "property_var";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the 'snake_case_function' method.
        public static readonly StringName snake_case_function = "snake_case_function";

        //
        // Summary:
        //     Cached name for the 'get_property_var' method.
        public static readonly StringName get_property_var = "get_property_var";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}