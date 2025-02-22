using System.Collections.Generic;
using GDParser;
using System.Linq;

namespace GDBridge.Generator;

static class Extensions
{
    public static string ToCSharpTypeString(this GdType type, IEnumerable<AvailableType> availableTypes) => (type.BuiltInType switch
    {
        GdBuiltInType.@int => "long",
        GdBuiltInType.@float => "double",
        GdBuiltInType.String => "string",
        GdBuiltInType.Vector2 => "Godot.Vector2",
        GdBuiltInType.Vector2i => "Godot.Vector2I",
        GdBuiltInType.Rect2 => "Godot.Rect2",
        GdBuiltInType.Rect2i => "Godot.Rect2I",
        GdBuiltInType.Vector3 => "Godot.Vector3",
        GdBuiltInType.Vector3i => "Godot.Vector3I",
        GdBuiltInType.Transform2D => "Godot.Transform2D",
        GdBuiltInType.Vector4 => "Godot.Vector4",
        GdBuiltInType.Vector4i => "Godot.Vector4I",
        GdBuiltInType.Plane => "Godot.Plane",
        GdBuiltInType.Quaternion => "Godot.Quaternion",
        GdBuiltInType.AABB => "Godot.Aabb",
        GdBuiltInType.Basis => "Godot.Basis",
        GdBuiltInType.Transform3D => "Godot.Transform3D",
        GdBuiltInType.Projection => "Godot.Projection",
        GdBuiltInType.Color => "Godot.Color",
        GdBuiltInType.StringName => "Godot.StringName",
        GdBuiltInType.NodePath => "Godot.NodePath",
        GdBuiltInType.RID => "Godot.Rid",
        GdBuiltInType.Object => "Godot.GodotObject",
        GdBuiltInType.Callable => "Godot.Callable",
        GdBuiltInType.Signal => "Godot.Signal",
        GdBuiltInType.Dictionary => "Godot.Collections.Dictionary",
        GdBuiltInType.Array => GetGDArrayString(type, availableTypes),
        GdBuiltInType.PackedByteArray => "byte[]",
        GdBuiltInType.PackedInt32Array => "int[]",
        GdBuiltInType.PackedInt64Array => "long[]",
        GdBuiltInType.PackedFloat32Array => "float[]",
        GdBuiltInType.PackedFloat64Array => "double[]",
        GdBuiltInType.PackedStringArray => "string[]",
        GdBuiltInType.PackedVector2Array => "Godot.Vector2[]",
        GdBuiltInType.PackedVector3Array => "Godot.Vector3[]",
        GdBuiltInType.PackedColorArray => "Godot.Color[]",
        _ when type.IsBuiltIn => $"{type.BuiltInType.ToString()}",
        _  => GetTypeName(type, availableTypes)
    });
    static string GetTypeName(GdType type, IEnumerable<AvailableType> availableTypes)
    {
        var csharpType = availableTypes.FirstOrDefault(t => t.Name == type.TypeString!);
        if(csharpType is null)
            return "Godot.Variant";

        if (string.IsNullOrWhiteSpace(csharpType.Namespace))
            return csharpType.Name;
        
        return $"{csharpType.Namespace}.{csharpType.Name}";
    }

    static string GetGDArrayString(GdType type, IEnumerable<AvailableType> availableTypes)
    {
        if (type is { IsTypedArray: true, ArrayType.IsBuiltIn: true } || availableTypes.Any(t => t.Name == type.ArrayType?.TypeString!))
            return $"Godot.Collections.Array<{type.ArrayType!.ToCSharpTypeString(availableTypes)}>";
        return "Godot.Collections.Array";
    }
}