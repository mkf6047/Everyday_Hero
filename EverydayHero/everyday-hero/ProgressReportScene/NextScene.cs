using Godot;
using System;

public partial class NextScene : Area2D
{
    bool mouseIn = false;

    public override void _Process(double delta)
    {
        if(mouseIn && Input.IsActionJustPressed("Interact"))
        {
		    PlayerStats.Instance.qssType = false;
            GetTree().CallDeferred("change_scene_to_file", "res://QuestSorting/QuestSortingScene.tscn");
        }
    }

    public virtual void MouseEnter(){ mouseIn = true; }
    public virtual void MouseExit(){ mouseIn = false; }
}
