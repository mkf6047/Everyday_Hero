using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class QuestSortingScene : Node2D
{
	Godot.Collections.Array<MoveableQuest> questStack = [];

	PackedScene questPreload = GD.Load<PackedScene>("res://QuestSorting/Random_Quest/RandomQuest.tscn");

	LeaderSprite currentHeroSprite;

	RichTextLabel heroDialouge;

	QssResults resultsDisplay;
	
	Node2D questHolder;

	ClassAndRank displayClassRank;

	bool readyComplete, calculateOnce, allPartiesSorted = false;

	int numofquest = 0;
	int partiesApplying, currentParty = 0;
	public int currentHero = 1;

	public override void _Ready()
	{
		questHolder = (Node2D)GetNode("QuestHolder");
		switch (PlayerStats.Instance.Rank)
		{
			case "SSS":
				partiesApplying = 15;
				break;
			case "SS":
				partiesApplying = 12;
				break;
			case "S":
				partiesApplying = 10;
				break;
			case "A":
				partiesApplying = 9;
				break;
			case "B":
				partiesApplying = 8;
				break;
			case "C":
				partiesApplying = 7;
				break;
			case "D":
				partiesApplying = 6;
				break;
			case "E":
				partiesApplying = 5;
				break;
			case "F":
				partiesApplying = 4;
				break;
			default:
				break;
		}
		while (PartyLists.Instance.parties[0][currentHero - 1].onQuest == true) { currentHero++; }
		resultsDisplay = (QssResults)GetNode("QSSResults");
		displayClassRank = (ClassAndRank)GetNode("PartyInformation/Class&Rank");
		currentHeroSprite = (LeaderSprite)GetNode("PartyInformation/LeaderSprite");
		GenerateQuests();
		//displayClassRank.LoadNextParty(currentParty);
		QSSTracker.Instance.ResetCounts();
		readyComplete = true;
		TutorialInfo.Instance.ActivateTutorial(3);
		heroDialouge = (RichTextLabel)GetNode("PartyInformation/Textbox");
		ChangeActiveHero(currentHero);
	}

	public override void _Process(double delta)
	{
		if ((numofquest <= 0) && readyComplete)
		{
			if (Input.IsActionJustPressed("Interact") && calculateOnce) { GetTree().CallDeferred("change_scene_to_file", "res://ProgressReportScene/AllPartyProgressReport.tscn"); }
			if (calculateOnce) { return; }
			if (PlayerStats.Instance.Rank == "Unemployed") { PlayerStats.Instance.Rank = "F"; }
			if (PlayerStats.Instance.QuestsSorted >= 440 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 10)) { PlayerStats.Instance.Rank = "SSS"; }
			else if (PlayerStats.Instance.QuestsSorted >= 210 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 9)) { PlayerStats.Instance.Rank = "SS"; }
			else if (PlayerStats.Instance.QuestsSorted >= 130 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 8)) { PlayerStats.Instance.Rank = "S"; }
			else if (PlayerStats.Instance.QuestsSorted >= 80 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 6)) { PlayerStats.Instance.Rank = "A"; }
			else if (PlayerStats.Instance.QuestsSorted >= 50 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 5)) { PlayerStats.Instance.Rank = "B"; }
			else if (PlayerStats.Instance.QuestsSorted >= 30 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 4)) { PlayerStats.Instance.Rank = "C"; }
			else if (PlayerStats.Instance.QuestsSorted >= 20 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 3)) { PlayerStats.Instance.Rank = "D"; }
			else if (PlayerStats.Instance.QuestsSorted >= 10 && (InvestmentBenefits.Instance.buildingLevels["Guildhall"] >= 2)) { PlayerStats.Instance.Rank = "E"; }
			PlayerStats.Instance.isInside = true;
			resultsDisplay.RevealResults("" + QSSTracker.Instance.acceptedQuests + ";" +
											QSSTracker.Instance.delayedQuests + ";" +
											QSSTracker.Instance.rejectedQuests + ";" +
											QSSTracker.Instance.rewards + ";");
			calculateOnce = true;
		}
		if (currentParty > partiesApplying - 1)
		{
			allPartiesSorted = true;
		}
	}

	public void GenerateQuests()
	{
		for (int i = 0; i <= 3; i++)
		{
			MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
			// bool isUnique = true;
			// do
			// {
			// 	if (numofquest > 0)
			// 	{
			// 		foreach (MoveableQuest a in questStack)
			// 		{
			// 			if (quest.questName == a.questName)
			// 			{
			// 				isUnique = false;
			// 			}
			// 		}
			// 		if (!isUnique) { quest = (MoveableQuest)questPreload.Instantiate(); }
			// 	}
			// 	else { isUnique = true; GD.Print(isUnique); }
			// } while (isUnique == false);
			questHolder.AddChild(quest);
			quest.Position = new Vector2((i + 1) * 200, 425);
			AddQuest(quest);
		}
	}

	// public void NewParty()
	// {
	// 	currentParty++;
	// 	displayClassRank.LoadNextParty(currentParty);
	// }

	public void AddQuest(MoveableQuest quest)
	{
		questStack.Append(quest);

		int count = 0;
		foreach (MoveableQuest q in questStack)
		{
			q.ZIndex = count;
			count++;
		}
		numofquest++;
	}

	public void PushQuestToTop(MoveableQuest quest)
	{
		questStack.Remove(quest);
		AddQuest(quest);
		numofquest--;
	}

	public void RemoveQuest(MoveableQuest quest)
	{
		questStack.Remove(quest);
		questHolder.RemoveChild(quest);
		quest.QueueFree();
		numofquest--;
	}

	public void UpdateQuesters()
    {
        currentHero = 1;
		while (PartyLists.Instance.parties[0][currentHero - 1].onQuest == true) { currentHero++; }
		ChangeActiveHero(currentHero);
		displayClassRank.UpdateQuesterStatus();
    }

	public void ChangeActiveHero(int change)
    {
		currentHero = change;
		heroDialouge.Text = "";
		switch (change)
			{
				case 1:
					currentHeroSprite.ReplaceSprite("Knight");
					heroDialouge.AppendText("Provide me with your most challenging quest!");
					break;
				case 2:
					currentHeroSprite.ReplaceSprite("Cleric");
					heroDialouge.AppendText("Where is my aid needed?");
					break;
				case 3:
					currentHeroSprite.ReplaceSprite("Mage");
					heroDialouge.AppendText("Who can I experim... HELP! Yeah help that's what I meant.");
					break;
				case 4:
					currentHeroSprite.ReplaceSprite("Monk");
					heroDialouge.AppendText("My fists hunger for victory!");
					break;
				case 5:
					currentHeroSprite.ReplaceSprite("Ranger");
					heroDialouge.AppendText("What business do you have with the woods?");
					break;
				case 6:
					currentHeroSprite.ReplaceSprite("Rogue");
					heroDialouge.AppendText("So… Whatcha need done?");
					break;
				default:
					currentHeroSprite.ReplaceSprite("Phillip");
					heroDialouge.AppendText("Looks like everyone is out right now! You're gonna have to delay or toss out today's quests.");
					break;
			}
    }
}
