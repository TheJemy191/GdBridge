//HintName: LocalPlayerBridge.cs
using GDBridge;
using Godot;

public partial class LocalPlayerBridge : GDScriptBridge
{
    public LocalPlayerBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "LocalPlayer";

    public void ready_to_play() => GdObject.Call(MethodName.ready_to_play);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the '_controller' property.
        public static readonly StringName _controller = "_controller";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the '_setup' method.
        public static readonly StringName _setup = "_setup";

        //
        // Summary:
        //     Cached name for the 'ready_to_play' method.
        public static readonly StringName ready_to_play = "ready_to_play";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}