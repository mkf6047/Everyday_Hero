using Godot;
using System;

public partial class ReinforceAdventurer : Area2D
{
    bool isColliding = false;
    AllPartyProgressReport manager;
    public override void _Ready()
    {
        manager = (AllPartyProgressReport)GetParent();
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
                    PartyLists.Instance.parties[0][report.thisQuester].goodbadprogress[0] *= 2;
                    if(PartyLists.Instance.parties[0][report.thisQuester].goodbadprogress[0] > 100){PartyLists.Instance.parties[0][report.thisQuester].goodbadprogress[0] = 100;}
                    manager.NextAvailableHero();
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
            MovingProgressReport report = (MovingProgressReport)body;
            isColliding = false;
        }
        catch
        {
            GD.PrintErr("Deposite area just stopped colliding with something other than a Quest.");
        }
    }
}
