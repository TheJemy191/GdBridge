//HintName: CardBridge.cs
using GDBridge;
using Godot;

public partial class CardBridge : GDScriptBridge
{
    public CardBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "Card";

    public Godot.Label name_label
    {
        get => GdObject.Get(PropertyName.name_label).As<Godot.Label>();
        set => GdObject.Set(PropertyName.name_label, Godot.Variant.From(value));
    }

    public Godot.Label cost_label
    {
        get => GdObject.Get(PropertyName.cost_label).As<Godot.Label>();
        set => GdObject.Set(PropertyName.cost_label, Godot.Variant.From(value));
    }

    public Variant setup(string name, string cost) => GdObject.Call(MethodName.setup, name, cost);

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'name_label' property.
        public static readonly StringName name_label = "name_label";

        //
        // Summary:
        //     Cached name for the 'cost_label' property.
        public static readonly StringName cost_label = "cost_label";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the 'setup' method.
        public static readonly StringName setup = "setup";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}