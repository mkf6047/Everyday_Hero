using Godot;
using System;
using System.Linq;

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
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/Menus/LoadSave.tscn");
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
                file.StoreLine("res://Maps/BuildingInteriors/PlayerHouseInterior/PlayerHouseInterior.tscn");
                file.StoreLine(":");
                for (int i = 0; i < TutorialInfo.Instance.tutorialComplete.Count(); i++)
                {
                    file.StoreLine(TutorialInfo.Instance.tutorialComplete[i].ToString());
                }
                file.Close();
            }
        }
    }
}
