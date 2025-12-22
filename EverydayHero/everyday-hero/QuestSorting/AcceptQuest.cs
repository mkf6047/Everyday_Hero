using Godot;
using System;
using System.Linq;

public partial class AcceptQuest : Area2D
{
	bool isColliding = false, outOfHeroes = false;
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
				if (manager.heroSelected && !quest.isComplete)
				{
					if(manager.currentHero == 7) 
					{
						if (!outOfHeroes)
						{
							manager.PhillipNotHero();
							outOfHeroes = true;
						}
						return; 
					}
					PlayerStats.Instance.QuestsSorted += 1;
					QSSTracker.Instance.acceptedQuests++;
					if (quest.needHelp)
					{
						if (quest.isDelayed)
						{
							QSSTracker.Instance.delayedHelp["res://QuestSorting/QuestInformation/" + quest.questType +"/"+ quest.questName + ".txt"].Remove(quest.heroInNeed);
						}
						PartyLists.Instance.parties[0][quest.heroInNeed].goodbadprogress[0] += 25;
						if (PartyLists.Instance.parties[0][quest.heroInNeed].goodbadprogress[0] > 100)
						{
							PartyLists.Instance.parties[0][quest.heroInNeed].goodbadprogress[0] = 100;
						}
						PartyLists.Instance.parties[0][manager.currentHero - 1].onQuest = true;
						manager.RemoveQuest(quest);
                    	manager.UpdateQuesters();
						manager.HideActiveHero();
                    	BackgroundNoise.Instance.PaperShuffle();

						return;
					}
					//PlayerStats.Instance.Coins += quest.questReward;
					PartyLists.Instance.parties[0][manager.currentHero - 1].currentQuestsTypes[0] = quest.questType;
					PartyLists.Instance.parties[0][manager.currentHero - 1].currentQuestsNames[0] = quest.questName;
					PartyLists.Instance.parties[0][manager.currentHero - 1].goodbadprogress[0] = 0;
					PartyLists.Instance.parties[0][manager.currentHero - 1].completionByRank[quest.questRank] += 1;
					if (PartyLists.Instance.parties[0][manager.currentHero - 1].daysRemainingOnQuest < quest.questDuration) 
					{
						PartyLists.Instance.parties[0][manager.currentHero - 1].daysRemainingOnQuest = quest.questDuration; 
					}
					PartyLists.Instance.parties[0][manager.currentHero - 1].questCompletionRewards.Add(quest.questReward);
					PartyLists.Instance.parties[0][manager.currentHero - 1].onQuest = true;
					bool iscompatable = false;
					foreach(string a in quest.bestHeroes)
                    {
                        if(a.Contains(PartyLists.Instance.parties[0][manager.currentHero - 1].heroClass)){ iscompatable = true; }
                    }
					PartyLists.Instance.parties[0][manager.currentHero - 1].compatableWithQuest = iscompatable;

					manager.RemoveQuest(quest);
                    manager.UpdateQuesters();
					manager.HideActiveHero();
                    BackgroundNoise.Instance.PaperShuffle();
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
