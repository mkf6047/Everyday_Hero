using Godot;
using System;

public partial class ConfirmName : Button
{
    LineEdit playername;
    public override void _Ready()
    {
        playername = (LineEdit)GetNode("../PlayerName");
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        if (playername.Text != "")
        {
            PlayerStats.Instance.PlayerName = playername.Text;
            GetTree().CallDeferred("change_scene_to_file", "res://DayTrackerScene/DayTracker.tscn");
        }
    }
}
