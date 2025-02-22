//HintName: TypedArrayBridge.cs
using GDBridge;
using Godot;

public partial class TypedArrayBridge : GDScriptBridge
{
    public TypedArrayBridge(GodotObject gdObject) : base(gdObject) {}

    public const string GDClassName = "TypedArray";

    public Godot.Collections.Array array_test
    {
        get => GdObject.Get(PropertyName.array_test).As<Godot.Collections.Array>();
        set => GdObject.Set(PropertyName.array_test, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Variant> array_variant
    {
        get => GdObject.Get(PropertyName.array_variant).As<Godot.Collections.Array<Variant>>();
        set => GdObject.Set(PropertyName.array_variant, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Aabb> array_aabb
    {
        get => GdObject.Get(PropertyName.array_aabb).As<Godot.Collections.Array<Godot.Aabb>>();
        set => GdObject.Set(PropertyName.array_aabb, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Basis> array_basis
    {
        get => GdObject.Get(PropertyName.array_basis).As<Godot.Collections.Array<Godot.Basis>>();
        set => GdObject.Set(PropertyName.array_basis, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<bool> array_bool
    {
        get => GdObject.Get(PropertyName.array_bool).As<Godot.Collections.Array<bool>>();
        set => GdObject.Set(PropertyName.array_bool, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Callable> array_callable
    {
        get => GdObject.Get(PropertyName.array_callable).As<Godot.Collections.Array<Godot.Callable>>();
        set => GdObject.Set(PropertyName.array_callable, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Color> array_color
    {
        get => GdObject.Get(PropertyName.array_color).As<Godot.Collections.Array<Godot.Color>>();
        set => GdObject.Set(PropertyName.array_color, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Collections.Dictionary> array_dictionary
    {
        get => GdObject.Get(PropertyName.array_dictionary).As<Godot.Collections.Array<Godot.Collections.Dictionary>>();
        set => GdObject.Set(PropertyName.array_dictionary, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<double> array_float
    {
        get => GdObject.Get(PropertyName.array_float).As<Godot.Collections.Array<double>>();
        set => GdObject.Set(PropertyName.array_float, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<long> array_int
    {
        get => GdObject.Get(PropertyName.array_int).As<Godot.Collections.Array<long>>();
        set => GdObject.Set(PropertyName.array_int, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.NodePath> array_nodepath
    {
        get => GdObject.Get(PropertyName.array_nodepath).As<Godot.Collections.Array<Godot.NodePath>>();
        set => GdObject.Set(PropertyName.array_nodepath, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.GodotObject> array_object
    {
        get => GdObject.Get(PropertyName.array_object).As<Godot.Collections.Array<Godot.GodotObject>>();
        set => GdObject.Set(PropertyName.array_object, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<byte[]> array_packedbytearray
    {
        get => GdObject.Get(PropertyName.array_packedbytearray).As<Godot.Collections.Array<byte[]>>();
        set => GdObject.Set(PropertyName.array_packedbytearray, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Color[]> array_packedcolorarray
    {
        get => GdObject.Get(PropertyName.array_packedcolorarray).As<Godot.Collections.Array<Godot.Color[]>>();
        set => GdObject.Set(PropertyName.array_packedcolorarray, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<float[]> array_packedfloat32array
    {
        get => GdObject.Get(PropertyName.array_packedfloat32array).As<Godot.Collections.Array<float[]>>();
        set => GdObject.Set(PropertyName.array_packedfloat32array, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<double[]> array_packedfloat64array
    {
        get => GdObject.Get(PropertyName.array_packedfloat64array).As<Godot.Collections.Array<double[]>>();
        set => GdObject.Set(PropertyName.array_packedfloat64array, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<int[]> array_packedint32array
    {
        get => GdObject.Get(PropertyName.array_packedint32array).As<Godot.Collections.Array<int[]>>();
        set => GdObject.Set(PropertyName.array_packedint32array, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<long[]> array_packedint64array
    {
        get => GdObject.Get(PropertyName.array_packedint64array).As<Godot.Collections.Array<long[]>>();
        set => GdObject.Set(PropertyName.array_packedint64array, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<string[]> array_packedstringarray
    {
        get => GdObject.Get(PropertyName.array_packedstringarray).As<Godot.Collections.Array<string[]>>();
        set => GdObject.Set(PropertyName.array_packedstringarray, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector2[]> array_packedvector2array
    {
        get => GdObject.Get(PropertyName.array_packedvector2array).As<Godot.Collections.Array<Godot.Vector2[]>>();
        set => GdObject.Set(PropertyName.array_packedvector2array, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector3[]> array_packedvector3array
    {
        get => GdObject.Get(PropertyName.array_packedvector3array).As<Godot.Collections.Array<Godot.Vector3[]>>();
        set => GdObject.Set(PropertyName.array_packedvector3array, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Plane> array_plane
    {
        get => GdObject.Get(PropertyName.array_plane).As<Godot.Collections.Array<Godot.Plane>>();
        set => GdObject.Set(PropertyName.array_plane, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Projection> array_projection
    {
        get => GdObject.Get(PropertyName.array_projection).As<Godot.Collections.Array<Godot.Projection>>();
        set => GdObject.Set(PropertyName.array_projection, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Quaternion> array_quaternion
    {
        get => GdObject.Get(PropertyName.array_quaternion).As<Godot.Collections.Array<Godot.Quaternion>>();
        set => GdObject.Set(PropertyName.array_quaternion, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Rect2> array_rect2
    {
        get => GdObject.Get(PropertyName.array_rect2).As<Godot.Collections.Array<Godot.Rect2>>();
        set => GdObject.Set(PropertyName.array_rect2, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Rect2I> array_rect2i
    {
        get => GdObject.Get(PropertyName.array_rect2i).As<Godot.Collections.Array<Godot.Rect2I>>();
        set => GdObject.Set(PropertyName.array_rect2i, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Rid> array_rid
    {
        get => GdObject.Get(PropertyName.array_rid).As<Godot.Collections.Array<Godot.Rid>>();
        set => GdObject.Set(PropertyName.array_rid, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Signal> array_signal
    {
        get => GdObject.Get(PropertyName.array_signal).As<Godot.Collections.Array<Godot.Signal>>();
        set => GdObject.Set(PropertyName.array_signal, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<string> array_string
    {
        get => GdObject.Get(PropertyName.array_string).As<Godot.Collections.Array<string>>();
        set => GdObject.Set(PropertyName.array_string, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.StringName> array_stringname
    {
        get => GdObject.Get(PropertyName.array_stringname).As<Godot.Collections.Array<Godot.StringName>>();
        set => GdObject.Set(PropertyName.array_stringname, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Transform2D> array_transform2d
    {
        get => GdObject.Get(PropertyName.array_transform2d).As<Godot.Collections.Array<Godot.Transform2D>>();
        set => GdObject.Set(PropertyName.array_transform2d, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Transform3D> array_transform3d
    {
        get => GdObject.Get(PropertyName.array_transform3d).As<Godot.Collections.Array<Godot.Transform3D>>();
        set => GdObject.Set(PropertyName.array_transform3d, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector2> array_vector2
    {
        get => GdObject.Get(PropertyName.array_vector2).As<Godot.Collections.Array<Godot.Vector2>>();
        set => GdObject.Set(PropertyName.array_vector2, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector2I> array_vector2i
    {
        get => GdObject.Get(PropertyName.array_vector2i).As<Godot.Collections.Array<Godot.Vector2I>>();
        set => GdObject.Set(PropertyName.array_vector2i, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector3> array_vector3
    {
        get => GdObject.Get(PropertyName.array_vector3).As<Godot.Collections.Array<Godot.Vector3>>();
        set => GdObject.Set(PropertyName.array_vector3, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector3I> array_vector3i
    {
        get => GdObject.Get(PropertyName.array_vector3i).As<Godot.Collections.Array<Godot.Vector3I>>();
        set => GdObject.Set(PropertyName.array_vector3i, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector4> array_vector4
    {
        get => GdObject.Get(PropertyName.array_vector4).As<Godot.Collections.Array<Godot.Vector4>>();
        set => GdObject.Set(PropertyName.array_vector4, Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector4I> array_vector4i
    {
        get => GdObject.Get(PropertyName.array_vector4i).As<Godot.Collections.Array<Godot.Vector4I>>();
        set => GdObject.Set(PropertyName.array_vector4i, Godot.Variant.From(value));
    }

    /// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>
    public new class PropertyName : global::Godot.GodotObject.PropertyName
    {
        //
        // Summary:
        //     Cached name for the 'array_test' property.
        public static readonly StringName array_test = "array_test";

        //
        // Summary:
        //     Cached name for the 'array_variant' property.
        public static readonly StringName array_variant = "array_variant";

        //
        // Summary:
        //     Cached name for the 'array_aabb' property.
        public static readonly StringName array_aabb = "array_aabb";

        //
        // Summary:
        //     Cached name for the 'array_basis' property.
        public static readonly StringName array_basis = "array_basis";

        //
        // Summary:
        //     Cached name for the 'array_bool' property.
        public static readonly StringName array_bool = "array_bool";

        //
        // Summary:
        //     Cached name for the 'array_callable' property.
        public static readonly StringName array_callable = "array_callable";

        //
        // Summary:
        //     Cached name for the 'array_color' property.
        public static readonly StringName array_color = "array_color";

        //
        // Summary:
        //     Cached name for the 'array_dictionary' property.
        public static readonly StringName array_dictionary = "array_dictionary";

        //
        // Summary:
        //     Cached name for the 'array_float' property.
        public static readonly StringName array_float = "array_float";

        //
        // Summary:
        //     Cached name for the 'array_int' property.
        public static readonly StringName array_int = "array_int";

        //
        // Summary:
        //     Cached name for the 'array_nodepath' property.
        public static readonly StringName array_nodepath = "array_nodepath";

        //
        // Summary:
        //     Cached name for the 'array_object' property.
        public static readonly StringName array_object = "array_object";

        //
        // Summary:
        //     Cached name for the 'array_packedbytearray' property.
        public static readonly StringName array_packedbytearray = "array_packedbytearray";

        //
        // Summary:
        //     Cached name for the 'array_packedcolorarray' property.
        public static readonly StringName array_packedcolorarray = "array_packedcolorarray";

        //
        // Summary:
        //     Cached name for the 'array_packedfloat32array' property.
        public static readonly StringName array_packedfloat32array = "array_packedfloat32array";

        //
        // Summary:
        //     Cached name for the 'array_packedfloat64array' property.
        public static readonly StringName array_packedfloat64array = "array_packedfloat64array";

        //
        // Summary:
        //     Cached name for the 'array_packedint32array' property.
        public static readonly StringName array_packedint32array = "array_packedint32array";

        //
        // Summary:
        //     Cached name for the 'array_packedint64array' property.
        public static readonly StringName array_packedint64array = "array_packedint64array";

        //
        // Summary:
        //     Cached name for the 'array_packedstringarray' property.
        public static readonly StringName array_packedstringarray = "array_packedstringarray";

        //
        // Summary:
        //     Cached name for the 'array_packedvector2array' property.
        public static readonly StringName array_packedvector2array = "array_packedvector2array";

        //
        // Summary:
        //     Cached name for the 'array_packedvector3array' property.
        public static readonly StringName array_packedvector3array = "array_packedvector3array";

        //
        // Summary:
        //     Cached name for the 'array_plane' property.
        public static readonly StringName array_plane = "array_plane";

        //
        // Summary:
        //     Cached name for the 'array_projection' property.
        public static readonly StringName array_projection = "array_projection";

        //
        // Summary:
        //     Cached name for the 'array_quaternion' property.
        public static readonly StringName array_quaternion = "array_quaternion";

        //
        // Summary:
        //     Cached name for the 'array_rect2' property.
        public static readonly StringName array_rect2 = "array_rect2";

        //
        // Summary:
        //     Cached name for the 'array_rect2i' property.
        public static readonly StringName array_rect2i = "array_rect2i";

        //
        // Summary:
        //     Cached name for the 'array_rid' property.
        public static readonly StringName array_rid = "array_rid";

        //
        // Summary:
        //     Cached name for the 'array_signal' property.
        public static readonly StringName array_signal = "array_signal";

        //
        // Summary:
        //     Cached name for the 'array_string' property.
        public static readonly StringName array_string = "array_string";

        //
        // Summary:
        //     Cached name for the 'array_stringname' property.
        public static readonly StringName array_stringname = "array_stringname";

        //
        // Summary:
        //     Cached name for the 'array_transform2d' property.
        public static readonly StringName array_transform2d = "array_transform2d";

        //
        // Summary:
        //     Cached name for the 'array_transform3d' property.
        public static readonly StringName array_transform3d = "array_transform3d";

        //
        // Summary:
        //     Cached name for the 'array_vector2' property.
        public static readonly StringName array_vector2 = "array_vector2";

        //
        // Summary:
        //     Cached name for the 'array_vector2i' property.
        public static readonly StringName array_vector2i = "array_vector2i";

        //
        // Summary:
        //     Cached name for the 'array_vector3' property.
        public static readonly StringName array_vector3 = "array_vector3";

        //
        // Summary:
        //     Cached name for the 'array_vector3i' property.
        public static readonly StringName array_vector3i = "array_vector3i";

        //
        // Summary:
        //     Cached name for the 'array_vector4' property.
        public static readonly StringName array_vector4 = "array_vector4";

        //
        // Summary:
        //     Cached name for the 'array_vector4i' property.
        public static readonly StringName array_vector4i = "array_vector4i";
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