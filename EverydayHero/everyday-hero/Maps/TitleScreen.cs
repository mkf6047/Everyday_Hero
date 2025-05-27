using Godot;
using System;

public partial class TitleScreen : Node2D
{

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionPressed("Interact"))
        {
            GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
        }
    }
}
