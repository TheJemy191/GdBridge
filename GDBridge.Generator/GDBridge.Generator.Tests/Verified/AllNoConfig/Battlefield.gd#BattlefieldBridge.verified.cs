//HintName: BattlefieldBridge.cs
using GDBridge;
using Godot;

namespace TestNamespace
{
    public partial class BattlefieldBridge : GDScriptBridge
    {
        public BattlefieldBridge(GodotObject gdObject) : base(gdObject) {}

        public const string GDClassName = "Battlefield";

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
}