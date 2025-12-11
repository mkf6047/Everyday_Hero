using Godot;
using System;

public partial class DelayQuest : Area2D
{
    bool isColliding = false;
    QuestSortingScene manager;
    Sprite2D mySprite;
    Texture2D collidingSprite, notCollidingSprite;
    public override void _Ready()
    {
        manager = (QuestSortingScene)GetParent();
        mySprite = (Sprite2D)GetNode("Sprite2D");
        collidingSprite = GD.Load<Texture2D>("res://Sprites/QuestSprites/Delay-Quest-Hover.png");
        notCollidingSprite = GD.Load<Texture2D>("res://Sprites/Updated-Delay-Bin.png");
    }

    public override void _Process(double delta)
    {
        try
        {
            if (isColliding)
            {
                MoveableQuest quest = (MoveableQuest)GetOverlappingBodies()[0];
                if (!quest.Dragging)
                {
                    QSSTracker.Instance.delayedQuests++;
                    manager.RemoveQuest(quest);
                    manager.UpdateQuesters();
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
            MoveableQuest quest = (MoveableQuest)body;
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
            MoveableQuest quest = (MoveableQuest)body;
            isColliding = false;
        }
        catch
        {
            GD.PrintErr("Deposite area just stopped colliding with something other than a Quest.");
        }
    }
}
