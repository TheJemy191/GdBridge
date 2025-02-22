using Godot;

namespace GDBridge.Generator.Sample;

class Sample : Node
{
    [Export(PropertyHint.NodePathValidTypes, ArenaBridge.GDClassName)] NodePath arena = null!;
        
    void Init()
    {
        var arenaBridge = ArenaBridge.From(GetNode(arena));
        
        arenaBridge.on_configure(42);

        //var chooseDeckBridge = new ChooseDeckBridge();
        //chooseDeckBridge.choose_deck();
        //chooseDeckBridge.QueueFree();
    }
}