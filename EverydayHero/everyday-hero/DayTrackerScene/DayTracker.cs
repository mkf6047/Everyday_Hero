using Godot;
using System;

public partial class DayTracker : Node2D
{
    public override void _Ready()
    {
        BackgroundNoise.Instance.NighttimeMusic();
		for(int i = 0; i < 6; i++)
        {
            if (PartyLists.Instance.parties[0][i].daysRemainingOnQuest <= 0)
            {
                PartyLists.Instance.parties[0][i].onQuest = false;
            }
        }
        PlayerStats.Instance.DaysPassed += 1;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Interact"))
        {
            PlayerStats.Instance.qssType = true;
            GetTree().CallDeferred("change_scene_to_file", "res://QuestSorting/QuestSortingScene.tscn");
        }
    }

}
