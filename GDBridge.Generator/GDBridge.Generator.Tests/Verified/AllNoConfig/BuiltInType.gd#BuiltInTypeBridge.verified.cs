//HintName: BuiltInTypeBridge.cs
using GDBridge;
using Godot;

public partial class BuiltInTypeBridge : GDScriptBridge
{
    public BuiltInTypeBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "BuiltInType";

    public Variant var_variant
    {
        get => GdObject.Get(PropertyName.var_variant);
        set => GdObject.Set(PropertyName.var_variant, Godot.Variant.From(value));
    }

    public Godot.Aabb var_aabb
    {
        get => GdObject.Get(PropertyName.var_aabb).As<Godot.Aabb>();
        set => GdObject.Set(PropertyName.var_aabb, Godot.Variant.From(value));
    }

    public Godot.Collections.Array var_array
    {
        get => GdObject.Get(PropertyName.var_array).As<Godot.Collections.Array>();
        set => GdObject.Set(PropertyName.var_array, Godot.Variant.From(value));
    }

    public Godot.Basis var_basis
    {
        get => GdObject.Get(PropertyName.var_basis).As<Godot.Basis>();
        set => GdObject.Set(PropertyName.var_basis, Godot.Variant.From(value));
    }

    public bool var_bool
    {
        get => GdObject.Get(PropertyName.var_bool).As<bool>();
        set => GdObject.Set(PropertyName.var_bool, Godot.Variant.From(value));
    }

    public Godot.Callable var_callable
    {
        get => GdObject.Get(PropertyName.var_callable).As<Godot.Callable>();
        set => GdObject.Set(PropertyName.var_callable, Godot.Variant.From(value));
    }

    public Godot.Color var_color
    {
        get => GdObject.Get(PropertyName.var_color).As<Godot.Color>();
        set => GdObject.Set(PropertyName.var_color, Godot.Variant.From(value));
    }

    public Godot.Collections.Dictionary var_dictionary
    {
        get => GdObject.Get(PropertyName.var_dictionary).As<Godot.Collections.Dictionary>();
        set => GdObject.Set(PropertyName.var_dictionary, Godot.Variant.From(value));
    }

    public double var_float
    {
        get => GdObject.Get(PropertyName.var_float).As<double>();
        set => GdObject.Set(PropertyName.var_float, Godot.Variant.From(value));
    }

    public long var_int
    {
        get => GdObject.Get(PropertyName.var_int).As<long>();
        set => GdObject.Set(PropertyName.var_int, Godot.Variant.From(value));
    }

    public Godot.NodePath var_nodepath
    {
        get => GdObject.Get(PropertyName.var_nodepath).As<Godot.NodePath>();
        set => GdObject.Set(PropertyName.var_nodepath, Godot.Variant.From(value));
    }

    public Godot.GodotObject var_object
    {
        get => GdObject.Get(PropertyName.var_object).As<Godot.GodotObject>();
        set => GdObject.Set(PropertyName.var_object, Godot.Variant.From(value));
    }

    public byte[] var_packedbytearray
    {
        get => GdObject.Get(PropertyName.var_packedbytearray).As<byte[]>();
        set => GdObject.Set(PropertyName.var_packedbytearray, Godot.Variant.From(value));
    }

    public Godot.Color[] var_packedcolorarray
    {
        get => GdObject.Get(PropertyName.var_packedcolorarray).As<Godot.Color[]>();
        set => GdObject.Set(PropertyName.var_packedcolorarray, Godot.Variant.From(value));
    }

    public float[] var_packedfloat32array
    {
        get => GdObject.Get(PropertyName.var_packedfloat32array).As<float[]>();
        set => GdObject.Set(PropertyName.var_packedfloat32array, Godot.Variant.From(value));
    }

    public double[] var_packedfloat64array
    {
        get => GdObject.Get(PropertyName.var_packedfloat64array).As<double[]>();
        set => GdObject.Set(PropertyName.var_packedfloat64array, Godot.Variant.From(value));
    }

    public int[] var_packedint32array
    {
        get => GdObject.Get(PropertyName.var_packedint32array).As<int[]>();
        set => GdObject.Set(PropertyName.var_packedint32array, Godot.Variant.From(value));
    }

    public long[] var_packedint64array
    {
        get => GdObject.Get(PropertyName.var_packedint64array).As<long[]>();
        set => GdObject.Set(PropertyName.var_packedint64array, Godot.Variant.From(value));
    }

    public string[] var_packedstringarray
    {
        get => GdObject.Get(PropertyName.var_packedstringarray).As<string[]>();
        set => GdObject.Set(PropertyName.var_packedstringarray, Godot.Variant.From(value));
    }

    public Godot.Vector2[] var_packedvector2array
    {
        get => GdObject.Get(PropertyName.var_packedvector2array).As<Godot.Vector2[]>();
        set => GdObject.Set(PropertyName.var_packedvector2array, Godot.Variant.From(value));
    }

    public Godot.Vector3[] var_packedvector3array
    {
        get => GdObject.Get(PropertyName.var_packedvector3array).As<Godot.Vector3[]>();
        set => GdObject.Set(PropertyName.var_packedvector3array, Godot.Variant.From(value));
    }

    public Godot.Plane var_plane
    {
        get => GdObject.Get(PropertyName.var_plane).As<Godot.Plane>();
        set => GdObject.Set(PropertyName.var_plane, Godot.Variant.From(value));
    }

    public Godot.Projection var_projection
    {
        get => GdObject.Get(PropertyName.var_projection).As<Godot.Projection>();
        set => GdObject.Set(PropertyName.var_projection, Godot.Variant.From(value));
    }

    public Godot.Quaternion var_quaternion
    {
        get => GdObject.Get(PropertyName.var_quaternion).As<Godot.Quaternion>();
        set => GdObject.Set(PropertyName.var_quaternion, Godot.Variant.From(value));
    }

    public Godot.Rect2 var_rect2
    {
        get => GdObject.Get(PropertyName.var_rect2).As<Godot.Rect2>();
        set => GdObject.Set(PropertyName.var_rect2, Godot.Variant.From(value));
    }

    public Godot.Rect2I var_rect2i
    {
        get => GdObject.Get(PropertyName.var_rect2i).As<Godot.Rect2I>();
        set => GdObject.Set(PropertyName.var_rect2i, Godot.Variant.From(value));
    }

    public Godot.Rid var_rid
    {
        get => GdObject.Get(PropertyName.var_rid).As<Godot.Rid>();
        set => GdObject.Set(PropertyName.var_rid, Godot.Variant.From(value));
    }

    public Godot.Signal var_signal
    {
        get => GdObject.Get(PropertyName.var_signal).As<Godot.Signal>();
        set => GdObject.Set(PropertyName.var_signal, Godot.Variant.From(value));
    }

    public string var_string
    {
        get => GdObject.Get(PropertyName.var_string).As<string>();
        set => GdObject.Set(PropertyName.var_string, Godot.Variant.From(value));
    }

    public Godot.StringName var_stringname
    {
        get => GdObject.Get(PropertyName.var_stringname).As<Godot.StringName>();
        set => GdObject.Set(PropertyName.var_stringname, Godot.Variant.From(value));
    }

    public Godot.Transform2D var_transform2d
    {
        get => GdObject.Get(PropertyName.var_transform2d).As<Godot.Transform2D>();
        set => GdObject.Set(PropertyName.var_transform2d, Godot.Variant.From(value));
    }

    public Godot.Transform3D var_transform3d
    {
        get => GdObject.Get(PropertyName.var_transform3d).As<Godot.Transform3D>();
        set => GdObject.Set(PropertyName.var_transform3d, Godot.Variant.From(value));
    }

    public Godot.Vector2 var_vector2
    {
        get => GdObject.Get(PropertyName.var_vector2).As<Godot.Vector2>();
        set => GdObject.Set(PropertyName.var_vector2, Godot.Variant.From(value));
    }

    public Godot.Vector2I var_vector2i
    {
        get => GdObject.Get(PropertyName.var_vector2i).As<Godot.Vector2I>();
        set => GdObject.Set(PropertyName.var_vector2i, Godot.Variant.From(value));
    }

    public Godot.Vector3 var_vector3
    {
        get => GdObject.Get(PropertyName.var_vector3).As<Godot.Vector3>();
        set => GdObject.Set(PropertyName.var_vector3, Godot.Variant.From(value));
    }

    public Godot.Vector3I var_vector3i
    {
        get => GdObject.Get(PropertyName.var_vector3i).As<Godot.Vector3I>();
        set => GdObject.Set(PropertyName.var_vector3i, Godot.Variant.From(value));
    }

    public Godot.Vector4 var_vector4
    {
        get => GdObject.Get(PropertyName.var_vector4).As<Godot.Vector4>();
        set => GdObject.Set(PropertyName.var_vector4, Godot.Variant.From(value));
    }

    public Godot.Vector4I var_vector4i
    {
        get => GdObject.Get(PropertyName.var_vector4i).As<Godot.Vector4I>();
        set => GdObject.Set(PropertyName.var_vector4i, Godot.Variant.From(value));
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'var_variant' property.
        public static readonly StringName var_variant = "var_variant";

        //
        // Summary:
        //     Cached name for the 'var_aabb' property.
        public static readonly StringName var_aabb = "var_aabb";

        //
        // Summary:
        //     Cached name for the 'var_array' property.
        public static readonly StringName var_array = "var_array";

        //
        // Summary:
        //     Cached name for the 'var_basis' property.
        public static readonly StringName var_basis = "var_basis";

        //
        // Summary:
        //     Cached name for the 'var_bool' property.
        public static readonly StringName var_bool = "var_bool";

        //
        // Summary:
        //     Cached name for the 'var_callable' property.
        public static readonly StringName var_callable = "var_callable";

        //
        // Summary:
        //     Cached name for the 'var_color' property.
        public static readonly StringName var_color = "var_color";

        //
        // Summary:
        //     Cached name for the 'var_dictionary' property.
        public static readonly StringName var_dictionary = "var_dictionary";

        //
        // Summary:
        //     Cached name for the 'var_float' property.
        public static readonly StringName var_float = "var_float";

        //
        // Summary:
        //     Cached name for the 'var_int' property.
        public static readonly StringName var_int = "var_int";

        //
        // Summary:
        //     Cached name for the 'var_nodepath' property.
        public static readonly StringName var_nodepath = "var_nodepath";

        //
        // Summary:
        //     Cached name for the 'var_object' property.
        public static readonly StringName var_object = "var_object";

        //
        // Summary:
        //     Cached name for the 'var_packedbytearray' property.
        public static readonly StringName var_packedbytearray = "var_packedbytearray";

        //
        // Summary:
        //     Cached name for the 'var_packedcolorarray' property.
        public static readonly StringName var_packedcolorarray = "var_packedcolorarray";

        //
        // Summary:
        //     Cached name for the 'var_packedfloat32array' property.
        public static readonly StringName var_packedfloat32array = "var_packedfloat32array";

        //
        // Summary:
        //     Cached name for the 'var_packedfloat64array' property.
        public static readonly StringName var_packedfloat64array = "var_packedfloat64array";

        //
        // Summary:
        //     Cached name for the 'var_packedint32array' property.
        public static readonly StringName var_packedint32array = "var_packedint32array";

        //
        // Summary:
        //     Cached name for the 'var_packedint64array' property.
        public static readonly StringName var_packedint64array = "var_packedint64array";

        //
        // Summary:
        //     Cached name for the 'var_packedstringarray' property.
        public static readonly StringName var_packedstringarray = "var_packedstringarray";

        //
        // Summary:
        //     Cached name for the 'var_packedvector2array' property.
        public static readonly StringName var_packedvector2array = "var_packedvector2array";

        //
        // Summary:
        //     Cached name for the 'var_packedvector3array' property.
        public static readonly StringName var_packedvector3array = "var_packedvector3array";

        //
        // Summary:
        //     Cached name for the 'var_plane' property.
        public static readonly StringName var_plane = "var_plane";

        //
        // Summary:
        //     Cached name for the 'var_projection' property.
        public static readonly StringName var_projection = "var_projection";

        //
        // Summary:
        //     Cached name for the 'var_quaternion' property.
        public static readonly StringName var_quaternion = "var_quaternion";

        //
        // Summary:
        //     Cached name for the 'var_rect2' property.
        public static readonly StringName var_rect2 = "var_rect2";

        //
        // Summary:
        //     Cached name for the 'var_rect2i' property.
        public static readonly StringName var_rect2i = "var_rect2i";

        //
        // Summary:
        //     Cached name for the 'var_rid' property.
        public static readonly StringName var_rid = "var_rid";

        //
        // Summary:
        //     Cached name for the 'var_signal' property.
        public static readonly StringName var_signal = "var_signal";

        //
        // Summary:
        //     Cached name for the 'var_string' property.
        public static readonly StringName var_string = "var_string";

        //
        // Summary:
        //     Cached name for the 'var_stringname' property.
        public static readonly StringName var_stringname = "var_stringname";

        //
        // Summary:
        //     Cached name for the 'var_transform2d' property.
        public static readonly StringName var_transform2d = "var_transform2d";

        //
        // Summary:
        //     Cached name for the 'var_transform3d' property.
        public static readonly StringName var_transform3d = "var_transform3d";

        //
        // Summary:
        //     Cached name for the 'var_vector2' property.
        public static readonly StringName var_vector2 = "var_vector2";

        //
        // Summary:
        //     Cached name for the 'var_vector2i' property.
        public static readonly StringName var_vector2i = "var_vector2i";

        //
        // Summary:
        //     Cached name for the 'var_vector3' property.
        public static readonly StringName var_vector3 = "var_vector3";

        //
        // Summary:
        //     Cached name for the 'var_vector3i' property.
        public static readonly StringName var_vector3i = "var_vector3i";

        //
        // Summary:
        //     Cached name for the 'var_vector4' property.
        public static readonly StringName var_vector4 = "var_vector4";

        //
        // Summary:
        //     Cached name for the 'var_vector4i' property.
        public static readonly StringName var_vector4i = "var_vector4i";
    }

    /// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>
    public new class MethodName : global::Godot.GodotObject.MethodName
    {
    }

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}