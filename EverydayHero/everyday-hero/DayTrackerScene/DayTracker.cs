using Godot;
using System;

public partial class DayTracker : Node2D
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Interact"))
        {
            GetTree().CallDeferred("change_scene_to_file", "res://QuestSorting/QuestSortingScene.tscn");
        }
    }

}
