using Godot;
using System;

public partial class ProgressAccepted : Area2D
{
    bool isColliding = false;
    AllPartyProgressReport manager;
    Sprite2D mySprite;
    Texture2D collidingSprite, notCollidingSprite;
    public override void _Ready()
    {
        manager = (AllPartyProgressReport)GetParent();
        mySprite = (Sprite2D)GetNode("Sprite2D");
        collidingSprite = GD.Load<Texture2D>("res://Sprites/QuestSprites/Trash-Can-Hover.png");
        notCollidingSprite = GD.Load<Texture2D>("res://Sprites/QuestSprites/DisposeQuest.png");
    }

    public override void _Process(double delta)
    {
        try
        {
            if (isColliding)
            {
                MovingProgressReport report = (MovingProgressReport)GetOverlappingBodies()[0];
                if (!report.Dragging)
                {
                    //QSSTracker.Instance.rejectedQuests++;
                    manager.RemoveReport(report);
                }
            }
        }
        catch
        {

        }
    }


    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            mySprite.Texture = collidingSprite;
            MovingProgressReport report = (MovingProgressReport)body;
            isColliding = true;
        }
        catch
        {
            GD.PrintErr("Deposite area just collided with something other than a Quest.");
        }
    }

    public virtual void OnArea2DBodyExited(Node2D body)
    {
        try
        {
            mySprite.Texture = notCollidingSprite;
            MovingProgressReport report = (MovingProgressReport)body;
            isColliding = false;
        }
        catch
        {
            GD.PrintErr("Deposite area just stopped colliding with something other than a Quest.");
        }
    }
}
