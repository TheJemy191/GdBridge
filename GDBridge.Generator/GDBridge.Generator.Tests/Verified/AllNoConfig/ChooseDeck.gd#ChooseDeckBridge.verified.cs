//HintName: ChooseDeckBridge.cs
using GDBridge;
using Godot;

public partial class ChooseDeckBridge : GDScriptBridge
{
    public ChooseDeckBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "ChooseDeck";

    public Godot.PackedScene deckEntryScene
    {
        get => GdObject.Get(PropertyName.deckEntryScene).As<Godot.PackedScene>();
        set => GdObject.Set(PropertyName.deckEntryScene, Godot.Variant.From(value));
    }

    public Godot.PackedScene deckBuilderScene
    {
        get => GdObject.Get(PropertyName.deckBuilderScene).As<Godot.PackedScene>();
        set => GdObject.Set(PropertyName.deckBuilderScene, Godot.Variant.From(value));
    }

    public Variant setup(Godot.Collections.Array<CardGame.Core.Data.DeckData> decks) => GdObject.Call(MethodName.setup, decks);

    public long choose_deck() => GdObject.Call(MethodName.choose_deck).As<long>();

    public void new_deck() => GdObject.Call(MethodName.new_deck);

    public event System.Action<long> deck_choosen
    {
        add
        {
            Connect(SignalName.deck_choosen, global::Godot.Callable.From(value));
        }
        remove
        {
            Disconnect(SignalName.deck_choosen, global::Godot.Callable.From(value));
        }
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'deckEntryScene' property.
        public static readonly StringName deckEntryScene = "deckEntryScene";

        //
        // Summary:
        //     Cached name for the 'deckBuilderScene' property.
        public static readonly StringName deckBuilderScene = "deckBuilderScene";
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
        //     Cached name for the 'choose_deck' method.
        public static readonly StringName choose_deck = "choose_deck";

        //
        // Summary:
        //     Cached name for the 'new_deck' method.
        public static readonly StringName new_deck = "new_deck";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
        //
        // Summary:
        //     Cached name for the 'deck_choosen' signal.
        public static readonly StringName deck_choosen = "deck_choosen";
    }
}