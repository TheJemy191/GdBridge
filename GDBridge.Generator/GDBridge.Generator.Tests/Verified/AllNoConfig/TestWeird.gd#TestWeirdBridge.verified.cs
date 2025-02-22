//HintName: TestWeirdBridge.cs
using GDBridge;
using Godot;

public partial class TestWeirdBridge : GDScriptBridge
{
    public TestWeirdBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "TestWeird";

    public Godot.Variant chooseDeck
    {
        get => GdObject.Get(PropertyName.chooseDeck).As<Godot.Variant>();
        set => GdObject.Set(PropertyName.chooseDeck, Godot.Variant.From(value));
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'chooseDeck' property.
        public static readonly StringName chooseDeck = "chooseDeck";
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
        //     Cached name for the '_on_start_game_pressed' method.
        public static readonly StringName _on_start_game_pressed = "_on_start_game_pressed";

        //
        // Summary:
        //     Cached name for the '_on_edit_deck_pressed' method.
        public static readonly StringName _on_edit_deck_pressed = "_on_edit_deck_pressed";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}