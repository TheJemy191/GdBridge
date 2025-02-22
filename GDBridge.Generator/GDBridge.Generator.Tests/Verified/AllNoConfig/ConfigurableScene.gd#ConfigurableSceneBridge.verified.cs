//HintName: ConfigurableSceneBridge.cs
using GDBridge;
using Godot;

public partial class ConfigurableSceneBridge : GDScriptBridge
{
    public ConfigurableSceneBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "ConfigurableScene";

    public event System.Action<Variant> configure
    {
        add
        {
            Connect(SignalName.configure, global::Godot.Callable.From(value));
        }
        remove
        {
            Disconnect(SignalName.configure, global::Godot.Callable.From(value));
        }
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
        //
        // Summary:
        //     Cached name for the 'configure' signal.
        public static readonly StringName configure = "configure";
    }
}