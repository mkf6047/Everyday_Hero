using Godot;
using System;

public partial class QuestSortingScene : Node2D
{
    //press Interact Button (Z or Enter) to move to the save files
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionPressed("Interact"))
        {
            GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
        }
    }
}
