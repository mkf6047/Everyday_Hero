using Godot;
using System;

public partial class AfternoonBreak : Node2D
{
    public override void _Ready()
    {
        BackgroundNoise.Instance.NighttimeMusic();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Interact"))
        {
            PlayerStats.Instance.qssType = true;
            GetTree().CallDeferred("change_scene_to_file", "res://ProgressReportScene/AllPartyProgressReport.tscn");
        }
    }
}
