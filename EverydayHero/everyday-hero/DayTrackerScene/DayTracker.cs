using Godot;
using System;

public partial class DayTracker : Node2D
{
    public override void _Ready()
    {
        BackgroundNoise.Instance.NighttimeMusic();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Interact"))
        {
            GD.Print("SceneFilePath change begun");
            GetTree().CallDeferred("change_scene_to_file", "res://QuestSorting/QuestSortingScene.tscn");
            //GetTree().ChangeSceneToFile("res://QuestSorting/QuestSortingScene.tscn");
            GD.Print("SceneFilePath change sucessfully");
        }
    }

}
