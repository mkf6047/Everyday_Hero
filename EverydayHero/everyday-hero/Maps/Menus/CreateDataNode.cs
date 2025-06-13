using Godot;
using System;

public partial class CreateDataNode : Node2D
{
    public override void _Ready()
    {
        base._Ready();
        PlayerVariables PlayerInfo = GD.Load<PackedScene>("res://PlayerInformation/PlayerVariables.tscn").Instantiate<PlayerVariables>();
        GetTree().Root.AddChild(PlayerInfo);
    }

}
