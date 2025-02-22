//HintName: CardPilesBridge.cs
using GDBridge;
using Godot;

public partial class CardPilesBridge : GDScriptBridge
{
    public CardPilesBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "CardPiles";

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
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
        //     Cached name for the '_process' method.
        public static readonly StringName _process = "_process";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}