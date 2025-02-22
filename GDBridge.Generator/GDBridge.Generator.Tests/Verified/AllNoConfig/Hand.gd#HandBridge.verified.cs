//HintName: HandBridge.cs
using GDBridge;
using Godot;

public partial class HandBridge : GDScriptBridge
{
    public HandBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "Hand";

    public Godot.PackedScene card_scene
    {
        get => GdObject.Get(PropertyName.card_scene).As<Godot.PackedScene>();
        set => GdObject.Set(PropertyName.card_scene, Godot.Variant.From(value));
    }

    public Godot.Node card_container
    {
        get => GdObject.Get(PropertyName.card_container).As<Godot.Node>();
        set => GdObject.Set(PropertyName.card_container, Godot.Variant.From(value));
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'card_scene' property.
        public static readonly StringName card_scene = "card_scene";

        //
        // Summary:
        //     Cached name for the 'card_container' property.
        public static readonly StringName card_container = "card_container";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the '_add_card' method.
        public static readonly StringName _add_card = "_add_card";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}