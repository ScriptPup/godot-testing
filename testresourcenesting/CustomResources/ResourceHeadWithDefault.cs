using Godot;

[GlobalClass]
public partial class ResourceHeadWithDefault : Resource {

    [Export] public ResourceChild resourceChild = new ResourceChild();

}