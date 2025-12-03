using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class AllPartyProgressReport : Node2D
{
    Godot.Collections.Array<MovingProgressReport> reportStack = [];
	
	Node2D reportHolder;

	PartyInformation partyInfo;

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
				if(PartyLists.Instance.parties[0][i].daysRemainingOnQuest <= 0)
                {
                    PartyLists.Instance.parties[0][i].onQuest = false;
                }
            }
        }
		partyInfo = (PartyInformation)GetNode("PartyInformation");
		readyComplete = true;
        TutorialInfo.Instance.ActivateTutorial(5);
        PlayerStats.Instance.DaysPassed += 1;
	}

	public override void _Process(double delta)
	{
        if(numofreports <= 0)
        {
            GetTree().CallDeferred("change_scene_to_file", "res://DayTrackerScene/DayTracker.tscn");
        }
	}

	public void ChangeActiveHero(int input)
    {
        partyInfo.ChangeActiveHero(input);
    }

	public void NextAvailableHero()
    {
		currentHero = 1;
		while (PartyLists.Instance.parties[0][currentHero - 1].onQuest == true) { currentHero++; }
        ChangeActiveHero(currentHero);
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

	public void RemoveReport(MovingProgressReport report)
	{
		reportStack.Remove(report);
		reportHolder.RemoveChild(report);
		report.QueueFree();
		numofreports--;
	}
}

