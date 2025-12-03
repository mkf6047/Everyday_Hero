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
        BackgroundNoise.Instance.MainMusic();
        base._Ready();
    }

    //press Interact Button (Z or Enter) to move to the save files
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionPressed("Interact"))
        {
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/Menus/LoadType.tscn");
        }
        if (Input.IsActionPressed("cancel"))
        {
            GetTree().Quit();
        }
    }
    private void InitSaveFiles(string filepath)
    {
        if (!FileAccess.FileExists(filepath))
        {
            using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Write))
            {
                file.StoreLine("" + PlayerStats.Instance.PlayerName);             //player name
                file.StoreLine("" + PlayerStats.Instance.Coins);            //coins
                file.StoreLine("" + PlayerStats.Instance.Playtime);         //playtime
                file.StoreLine("" + PlayerStats.Instance.Rank);             //player rank
                file.StoreLine("" + PlayerStats.Instance.QuestsSorted);     //quests completed
                file.StoreLine("" + PlayerStats.Instance.CurrentScene);     //current scene
                file.StoreLine(":");            //deliminator - separate inventory from tutorials completed.
                for (int i = 0; i < TutorialInfo.Instance.tutorialComplete.Count(); i++)    //create storage for tutorial booleans
                {
                    file.StoreLine(TutorialInfo.Instance.tutorialComplete[i].ToString());
                }
                file.Close();                   //close file
            }
        }
    }
}
