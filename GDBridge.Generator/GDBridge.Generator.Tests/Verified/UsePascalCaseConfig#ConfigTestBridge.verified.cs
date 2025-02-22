//HintName: ConfigTestBridge.cs
using GDBridge;
using Godot;

public partial class ConfigTestBridge : GDScriptBridge
{
    public ConfigTestBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "ConfigTest";

    public Variant SnakeCaseVariable
    {
        get => GdObject.Get(PropertyName.SnakeCaseVariable);
        set => GdObject.Set(PropertyName.SnakeCaseVariable, Godot.Variant.From(value));
    }

    public Variant PropertyVar
    {
        get => GdObject.Get(PropertyName.PropertyVar);
        set => GdObject.Set(PropertyName.PropertyVar, Godot.Variant.From(value));
    }

    public Variant SnakeCaseFunction() => GdObject.Call(MethodName.SnakeCaseFunction);

    public Variant GetPropertyVar() => GdObject.Call(MethodName.GetPropertyVar);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'snake_case_variable' property.
        public static readonly StringName SnakeCaseVariable = "snake_case_variable";

        //
        // Summary:
        //     Cached name for the 'property_var' property.
        public static readonly StringName PropertyVar = "property_var";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the 'snake_case_function' method.
        public static readonly StringName SnakeCaseFunction = "snake_case_function";

        //
        // Summary:
        //     Cached name for the 'get_property_var' method.
        public static readonly StringName GetPropertyVar = "get_property_var";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}