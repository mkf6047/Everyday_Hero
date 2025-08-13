using Godot;
using System;

public partial class TitleScreen : Node2D
{
    public override void _Ready()
    {
        string save1 = "user://save_game_1.dat";
        string save2 = "user://save_game_2.dat";
        string save3 = "user://save_game_3.dat";
        InitSaveFiles(save1);
        InitSaveFiles(save2);
        InitSaveFiles(save3);

        base._Ready();
    }

    //press Interact Button (Z or Enter) to move to the save files
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionPressed("Interact"))
        {
            GetTree().ChangeSceneToFile("res://Maps/ExteriorMaps/MainScene.tscn");
        }
    }
    private void InitSaveFiles(string filepath)
    {
        if (!FileAccess.FileExists(filepath))
        {
            using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Write))
            {
                file.StoreLine("0");
                file.StoreLine("0.0");
                file.StoreLine("Unemployed");
            }
        }
    }
}
