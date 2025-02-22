//HintName: DeckBuilderBridge.cs
using GDBridge;
using Godot;

public partial class DeckBuilderBridge : GDScriptBridge
{
    public DeckBuilderBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "DeckBuilder";

    public bool createNewDeck
    {
        get => GdObject.Get(PropertyName.createNewDeck).As<bool>();
        set => GdObject.Set(PropertyName.createNewDeck, Godot.Variant.From(value));
    }

    public Variant on_configure(Variant args) => GdObject.Call(MethodName.on_configure, args);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'createNewDeck' property.
        public static readonly StringName createNewDeck = "createNewDeck";
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

        //
        // Summary:
        //     Cached name for the '_on_exit_button_pressed' method.
        public static readonly StringName _on_exit_button_pressed = "_on_exit_button_pressed";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}