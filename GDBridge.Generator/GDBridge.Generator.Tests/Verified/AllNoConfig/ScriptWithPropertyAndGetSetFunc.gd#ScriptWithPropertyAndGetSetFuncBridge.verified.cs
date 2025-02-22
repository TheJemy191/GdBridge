//HintName: ScriptWithPropertyAndGetSetFuncBridge.cs
using GDBridge;
using Godot;

public partial class ScriptWithPropertyAndGetSetFuncBridge : GDScriptBridge
{
    public ScriptWithPropertyAndGetSetFuncBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "ScriptWithPropertyAndGetSetFunc";

    public Variant limit_target
    {
        get => GdObject.Get(PropertyName.limit_target);
        set => GdObject.Set(PropertyName.limit_target, Godot.Variant.From(value));
    }

    public void set_limit_target_compat(Godot.NodePath value) => GdObject.Call(MethodName.set_limit_target_compat, value);

    public Godot.NodePath get_limit_target_compat() => GdObject.Call(MethodName.get_limit_target_compat).As<Godot.NodePath>();

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'limit_target' property.
        public static readonly StringName limit_target = "limit_target";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the 'set_limit_target' method.
        public static readonly StringName set_limit_target = "set_limit_target";

        //
        // Summary:
        //     Cached name for the 'get_limit_target' method.
        public static readonly StringName get_limit_target = "get_limit_target";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}