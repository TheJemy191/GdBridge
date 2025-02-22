//HintName: CardPathBridge.cs
using GDBridge;
using Godot;

public partial class CardPathBridge : GDScriptBridge
{
    public CardPathBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "CardPath";

    public long width
    {
        get => GdObject.Get(PropertyName.width).As<long>();
        set => GdObject.Set(PropertyName.width, Godot.Variant.From(value));
    }

    public long height
    {
        get => GdObject.Get(PropertyName.height).As<long>();
        set => GdObject.Set(PropertyName.height, Godot.Variant.From(value));
    }

    public double curve_ratio
    {
        get => GdObject.Get(PropertyName.curve_ratio).As<double>();
        set => GdObject.Set(PropertyName.curve_ratio, Godot.Variant.From(value));
    }

    public double separation
    {
        get => GdObject.Get(PropertyName.separation).As<double>();
        set => GdObject.Set(PropertyName.separation, Godot.Variant.From(value));
    }

    public double padding
    {
        get => GdObject.Get(PropertyName.padding).As<double>();
        set => GdObject.Set(PropertyName.padding, Godot.Variant.From(value));
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'width' property.
        public static readonly StringName width = "width";

        //
        // Summary:
        //     Cached name for the 'height' property.
        public static readonly StringName height = "height";

        //
        // Summary:
        //     Cached name for the 'curve_ratio' property.
        public static readonly StringName curve_ratio = "curve_ratio";

        //
        // Summary:
        //     Cached name for the 'separation' property.
        public static readonly StringName separation = "separation";

        //
        // Summary:
        //     Cached name for the 'padding' property.
        public static readonly StringName padding = "padding";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
        //
        // Summary:
        //     Cached name for the '_init' method.
        public static readonly StringName _init = "_init";

        //
        // Summary:
        //     Cached name for the '_ready' method.
        public static readonly StringName _ready = "_ready";

        //
        // Summary:
        //     Cached name for the '_update_curve' method.
        public static readonly StringName _update_curve = "_update_curve";

        //
        // Summary:
        //     Cached name for the '_card_added' method.
        public static readonly StringName _card_added = "_card_added";

        //
        // Summary:
        //     Cached name for the '_update_card_position' method.
        public static readonly StringName _update_card_position = "_update_card_position";

        //
        // Summary:
        //     Cached name for the '_compute_card_position' method.
        public static readonly StringName _compute_card_position = "_compute_card_position";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}