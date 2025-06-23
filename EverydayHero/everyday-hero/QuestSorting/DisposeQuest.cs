using Godot;
using System;

public partial class DisposeQuest : Area2D
{
    bool isColliding = false;
    QuestSortingScene manager;
    public override void _Ready()
    {
        manager = (QuestSortingScene)GetParent();
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
                    manager.RemoveQuest(quest);
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
            GD.Print("Dispose called");
            MoveableQuest quest = (MoveableQuest)body;
            isColliding = true;
            GD.Print("Dispose complete");
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
            MoveableQuest quest = (MoveableQuest)body;
            isColliding = false;
        }
        catch
        {
            GD.PrintErr("Deposite area just stopped colliding with something other than a Quest.");
        }
    }
}
