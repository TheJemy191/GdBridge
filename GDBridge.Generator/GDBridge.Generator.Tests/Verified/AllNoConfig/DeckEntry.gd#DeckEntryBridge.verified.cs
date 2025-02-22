//HintName: DeckEntryBridge.cs
using GDBridge;
using Godot;

public partial class DeckEntryBridge : GDScriptBridge
{
    public DeckEntryBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "DeckEntry";

    public long deckId
    {
        get => GdObject.Get(PropertyName.deckId).As<long>();
        set => GdObject.Set(PropertyName.deckId, Godot.Variant.From(value));
    }

    public Godot.Variant chooseDeck
    {
        get => GdObject.Get(PropertyName.chooseDeck).As<Godot.Variant>();
        set => GdObject.Set(PropertyName.chooseDeck, Godot.Variant.From(value));
    }

    public Variant setup(string deckName, long deckId, Godot.Variant chooseDeck) => GdObject.Call(MethodName.setup, deckName, deckId, chooseDeck);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'deckId' property.
        public static readonly StringName deckId = "deckId";

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
        //     Cached name for the 'setup' method.
        public static readonly StringName setup = "setup";

        //
        // Summary:
        //     Cached name for the '_on_pressed' method.
        public static readonly StringName _on_pressed = "_on_pressed";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}