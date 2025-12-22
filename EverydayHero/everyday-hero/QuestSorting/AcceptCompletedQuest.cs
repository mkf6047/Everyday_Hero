using Godot;
using System;

public partial class AcceptCompletedQuest : Area2D
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
				if (quest.isComplete)
				{
					PlayerStats.Instance.Coins += quest.questReward;
					QSSTracker.Instance.acceptedQuests++;
					manager.RemoveQuest(quest);
                    manager.UpdateQuesters();
					manager.HideActiveHero();
					//manager.NewParty();
				}
			}
		}
		catch (Exception ex)
		{
			GD.PrintErr("unable to complete process. error: " + ex.Message);
		}
	}


	public virtual void OnArea2DBodyEntered(Node2D body)
	{
		try
		{
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
			MoveableQuest quest = (MoveableQuest)body;
			isColliding = false;
		}
		catch
		{
			GD.PrintErr("Deposite area just stopped colliding with something other than a Quest.");
		}
	}
}
