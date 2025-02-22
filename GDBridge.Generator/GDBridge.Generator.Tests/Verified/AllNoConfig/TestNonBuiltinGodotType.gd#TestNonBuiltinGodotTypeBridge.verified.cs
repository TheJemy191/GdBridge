//HintName: TestNonBuiltinGodotTypeBridge.cs
using GDBridge;
using Godot;

public partial class TestNonBuiltinGodotTypeBridge : GDScriptBridge
{
    public TestNonBuiltinGodotTypeBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "TestNonBuiltinGodotType";

    public Godot.Node2D node
    {
        get => GdObject.Get(PropertyName.node).As<Godot.Node2D>();
        set => GdObject.Set(PropertyName.node, Godot.Variant.From(value));
    }

    public void on_configure(Godot.Node2D node) => GdObject.Call(MethodName.on_configure, node);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'node' property.
        public static readonly StringName node = "node";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the 'on_configure' method.
        public static readonly StringName on_configure = "on_configure";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}