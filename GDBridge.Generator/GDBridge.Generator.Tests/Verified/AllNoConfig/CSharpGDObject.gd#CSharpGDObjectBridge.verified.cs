//HintName: CSharpGDObjectBridge.cs
using GDBridge;
using Godot;

public partial class CSharpGDObjectBridge : GDScriptBridge
{
    public CSharpGDObjectBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "CSharpGDObject";

    public TestGDObject test_object
    {
        get => GdObject.Get(PropertyName.test_object).As<TestGDObject>();
        set => GdObject.Set(PropertyName.test_object, Godot.Variant.From(value));
    }

    public void on_configure(TestGDObject test_object) => GdObject.Call(MethodName.on_configure, test_object);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'test_object' property.
        public static readonly StringName test_object = "test_object";
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