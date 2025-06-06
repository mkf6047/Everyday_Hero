using Godot;
using System;

public partial class DeskInteract : Area2D
{
    Sprite2D NPCsprite;

    bool isColliding;

    public override void _Ready()
    {
        base._Ready();
        isColliding = false;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (isColliding) {
            if (Input.IsActionPressed("Interact"))
            {
                GetTree().ChangeSceneToFile("res://QuestSorting/QuestSortingScene.tscn");
            }
        }
    }



    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            isColliding = true;
            Sprite2D notice = (Sprite2D)GetNode("/root/BuildingInterior/Player/PlayerBody2D/Notice");
            notice.Call("ShowNotice");
        }
        catch
        {
            GD.PrintErr("Interactive item just collided with something other than a Player.");
        }
    }

    public virtual void OnArea2DBodyExited(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            isColliding = false;
            Sprite2D notice = (Sprite2D)GetNode("/root/BuildingInterior/Player/PlayerBody2D/Notice");
            notice.Call("HideNotice");
        }
        catch
        {
            GD.PrintErr("Interactive item just stopped colliding with something other than a Player.");
        }
    }
}
