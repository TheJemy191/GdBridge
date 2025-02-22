//HintName: SceneLoaderBridge.cs
using GDBridge;
using Godot;

public partial class SceneLoaderBridge : GDScriptBridge
{
    public SceneLoaderBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "SceneLoader";

    public Godot.PackedScene menuScene
    {
        get => GdObject.Get(PropertyName.menuScene).As<Godot.PackedScene>();
        set => GdObject.Set(PropertyName.menuScene, Godot.Variant.From(value));
    }

    public Godot.PackedScene arenaScene
    {
        get => GdObject.Get(PropertyName.arenaScene).As<Godot.PackedScene>();
        set => GdObject.Set(PropertyName.arenaScene, Godot.Variant.From(value));
    }

    public Godot.PackedScene deckbuilderScene
    {
        get => GdObject.Get(PropertyName.deckbuilderScene).As<Godot.PackedScene>();
        set => GdObject.Set(PropertyName.deckbuilderScene, Godot.Variant.From(value));
    }

    public Godot.Node current_scene
    {
        get => GdObject.Get(PropertyName.current_scene).As<Godot.Node>();
        set => GdObject.Set(PropertyName.current_scene, Godot.Variant.From(value));
    }

    public Variant goto_menu() => GdObject.Call(MethodName.goto_menu);

    public Variant goto_arena(long player_deck_id) => GdObject.Call(MethodName.goto_arena, player_deck_id);

    public Variant goto_deckbuilder(bool createNewDeck) => GdObject.Call(MethodName.goto_deckbuilder, createNewDeck);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'menuScene' property.
        public static readonly StringName menuScene = "menuScene";

        //
        // Summary:
        //     Cached name for the 'arenaScene' property.
        public static readonly StringName arenaScene = "arenaScene";

        //
        // Summary:
        //     Cached name for the 'deckbuilderScene' property.
        public static readonly StringName deckbuilderScene = "deckbuilderScene";

        //
        // Summary:
        //     Cached name for the 'current_scene' property.
        public static readonly StringName current_scene = "current_scene";
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
        //     Cached name for the 'goto_menu' method.
        public static readonly StringName goto_menu = "goto_menu";

        //
        // Summary:
        //     Cached name for the 'goto_arena' method.
        public static readonly StringName goto_arena = "goto_arena";

        //
        // Summary:
        //     Cached name for the 'goto_deckbuilder' method.
        public static readonly StringName goto_deckbuilder = "goto_deckbuilder";

        //
        // Summary:
        //     Cached name for the '_deferred_goto_scene' method.
        public static readonly StringName _deferred_goto_scene = "_deferred_goto_scene";

        //
        // Summary:
        //     Cached name for the '_configure_scene' method.
        public static readonly StringName _configure_scene = "_configure_scene";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}