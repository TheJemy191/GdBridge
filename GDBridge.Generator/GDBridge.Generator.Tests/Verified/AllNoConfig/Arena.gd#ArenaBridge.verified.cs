//HintName: ArenaBridge.cs
using GDBridge;
using Godot;

public partial class ArenaBridge : GDScriptBridge
{
    public ArenaBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "Arena";

    public Godot.NodePath game_startup
    {
        get => GdObject.Get(PropertyName.game_startup).As<Godot.NodePath>();
        set => GdObject.Set(PropertyName.game_startup, Godot.Variant.From(value));
    }

    public Variant on_configure(Variant deck_id_in) => GdObject.Call(MethodName.on_configure, deck_id_in);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the '_game_startup' property.
        public static readonly StringName _game_startup = "_game_startup";

        //
        // Summary:
        //     Cached name for the 'game_startup' property.
        public static readonly StringName game_startup = "game_startup";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the '_ready' method.
        public static readonly StringName _ready = "_ready";

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