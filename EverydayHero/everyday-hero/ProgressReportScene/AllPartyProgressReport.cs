using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class AllPartyProgressReport : Node2D
{
    Godot.Collections.Array<MovingProgressReport> reportStack = [];
	
	Node2D reportHolder;

	bool readyComplete, calculateOnce, allPartiesSorted = false;

	int numofreports = 6;
	int partiesApplying, currentParty = 0;
	int currentHero = 1;

	public override void _Ready()
	{
        reportHolder = (Node2D)GetNode("Reports");
		for (int i = 1; i <= numofreports; i++)
		{
			MovingProgressReport newReport = (MovingProgressReport)GetNode("Reports/ProgressReport" + i);
			reportStack.Append(newReport);
		}
		for(int i = 0; i < 6; i++)
        {
            if (PartyLists.Instance.parties[0][i].onQuest)
            {
                PartyLists.Instance.parties[0][i].daysRemainingOnQuest--;
            }
        }
		readyComplete = true;
        TutorialInfo.Instance.ActivateTutorial(3);
        PlayerStats.Instance.DaysPassed += 1;
	}

	public override void _Process(double delta)
	{
        
	}

	public void AddReport(MovingProgressReport report)
    {
		reportStack.Append(report);

		int count = 0;
		foreach (MovingProgressReport q in reportStack)
		{
			q.ZIndex = count;
			count++;
		}
		numofreports++;
	}

	public void PushReportToTop(MovingProgressReport report)
	{
		reportStack.Remove(report);
		AddReport(report);
		numofreports--;
	}

	public void RemoveQuest(MovingProgressReport report)
	{
		reportStack.Remove(report);
		reportHolder.RemoveChild(report);
		report.QueueFree();
		numofreports--;
	}

	// public void ChangeActiveHero(int change)
    // {
	// 	currentHero = change;
	// 	switch (change)
	// 	{
	// 		case 1:
	// 			currentHeroSprite.ReplaceSprite("Knight");
	// 			break;
	// 		case 2:
	// 			currentHeroSprite.ReplaceSprite("Cleric");
	// 			break;
	// 		case 3:
	// 			currentHeroSprite.ReplaceSprite("Mage");
	// 			break;
	// 		case 4:
	// 			currentHeroSprite.ReplaceSprite("Monk");
	// 			break;
	// 		case 5:
	// 			currentHeroSprite.ReplaceSprite("Ranger");
	// 			break;
	// 		case 6:
	// 			currentHeroSprite.ReplaceSprite("Rogue");
	// 			break;
	// 		default:
	// 			currentHeroSprite.ReplaceSprite("Knight");
	// 			break;
	// 	}
    // }
}

