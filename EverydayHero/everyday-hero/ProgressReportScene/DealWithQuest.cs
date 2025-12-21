using Godot;
using System;

public partial class DealWithQuest : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
		PlayerStats.Instance.qssType = false;
        GetTree().CallDeferred("change_scene_to_file", "res://QuestSorting/QuestSortingScene.tscn");
    }
}
