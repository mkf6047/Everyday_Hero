using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class QuestSortingScene : Node2D
{
	public Godot.Collections.Array<MoveableQuest> questStack = [];

	PackedScene questPreload = GD.Load<PackedScene>("res://QuestSorting/Random_Quest/RandomQuest.tscn");

	LeaderSprite currentHeroSprite;

	RichTextLabel heroDialouge, heroName;

	QssResults resultsDisplay;
	
	Node2D questHolder;

	ClassAndRank displayClassRank;

	HeroList heroNameDisplay;

	AcceptCompletedQuest completedQuestReceptacle;

	bool readyComplete = false, calculateOnce = false, allPartiesSorted = false;

	int numofquest = 0;
	int partiesApplying, currentParty = 0;
	public int currentHero = 1;
	public bool heroSelected = false;

	public override void _Ready()
	{
		questHolder = (Node2D)GetNode("QuestHolder");
		switch (PlayerStats.Instance.Rank)
		{
			case "SSS":
			case "SS":
			case "S":
				partiesApplying = 6;
				break;
			case "A":
			case "B":
			case "C":
				partiesApplying = 5;
				break;
			case "D":
			case "E":
			case "F":
				partiesApplying = 4;
				break;
			default:
				break;
		}
		resultsDisplay = (QssResults)GetNode("QSSResults");
		displayClassRank = (ClassAndRank)GetNode("PartyInformation/Class&Rank");
		currentHeroSprite = (LeaderSprite)GetNode("PartyInformation/LeaderSprite");
		heroNameDisplay = (HeroList)GetNode("PartyInformation/HeroList/Textbox");
		completedQuestReceptacle = (AcceptCompletedQuest)GetNode("AcceptCompletedQuest");
		if (PlayerStats.Instance.qssType)
		{
			GenerateQuests();
			GenerateDelayedQuests();
		}
		else
		{
			GenerateCompletedQuests();
			GenerateDelayedHelp();
		}
		//displayClassRank.LoadNextParty(currentParty);
		QSSTracker.Instance.ResetCounts();
		SetDeferred("readyComplete", true);
		//if(TutorialInfo.Instance.tutorialComplete[3]){TutorialInfo.Instance.ActivateTutorial(4);}
		heroDialouge = (RichTextLabel)GetNode("PartyInformation/Textbox");
		heroName = (RichTextLabel)GetNode("PartyInformation/HeroName");
		UpdateQuesters();
		BackgroundNoise.Instance.MainMusic();
	}

	public override void _Process(double delta)
	{
		if ((numofquest <= 0) && readyComplete)
		{
			if (Input.IsActionJustPressed("Interact") && calculateOnce) 
			{
				if (PlayerStats.Instance.qssType)
				{
					GetTree().CallDeferred("change_scene_to_file", "res://DayTrackerScene/NoonBreak/AfternoonBreak.tscn"); 
				}
				else
				{
					GetTree().CallDeferred("change_scene_to_file", "res://DayTrackerScene/DayTracker.tscn"); 
				}
			}
			if (calculateOnce) { return; }
			if (PlayerStats.Instance.Rank == "Unemployed") { PlayerStats.Instance.Rank = "F"; }
			if (PlayerStats.Instance.QuestsSorted >= 440) { PlayerStats.Instance.Rank = "SSS"; }
			else if (PlayerStats.Instance.QuestsSorted >= 210) { PlayerStats.Instance.Rank = "SS"; }
			else if (PlayerStats.Instance.QuestsSorted >= 130) { PlayerStats.Instance.Rank = "S"; }
			else if (PlayerStats.Instance.QuestsSorted >= 80) { PlayerStats.Instance.Rank = "A"; }
			else if (PlayerStats.Instance.QuestsSorted >= 50) { PlayerStats.Instance.Rank = "B"; }
			else if (PlayerStats.Instance.QuestsSorted >= 30) { PlayerStats.Instance.Rank = "C"; }
			else if (PlayerStats.Instance.QuestsSorted >= 20) { PlayerStats.Instance.Rank = "D"; }
			else if (PlayerStats.Instance.QuestsSorted >= 10) { PlayerStats.Instance.Rank = "E"; }
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
			questHolder.AddChild(quest);
			quest.Position = new Vector2(150 + (i + 1) * 175, 425);
			AddQuest(quest);
		}
		TutorialInfo.Instance.ActivateTutorial(3);
	}

	public void GenerateCompletedQuests()
	{
		int returningReports = 0;
		for(int i = 0; i < 6; i++)
		{
			if((PartyLists.Instance.parties[0][i].daysRemainingOnQuest <= 0) && PartyLists.Instance.parties[0][i].onQuest)
            {	
				MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
				questHolder.AddChild(quest);
				string holder = "res://QuestSorting/QuestInformation/" + PartyLists.Instance.parties[0][i].currentQuestsTypes[0] +"/"+ PartyLists.Instance.parties[0][i].currentQuestsNames[0] + ".txt";
				quest.SpecificQuest(holder);
				//quest.CallDeferred("SpecificQuest", holder);
				returningReports++;
				if(PartyLists.Instance.parties[0][i].questPassed){ quest.Completed(); } else{ quest.NeedsWork(i); }
				quest.Position = new Vector2(150 + (returningReports * 175), 425);
				AddQuest(quest);
            }
		}
		if(returningReports == 0)
		{
			completedQuestReceptacle.Hide();
		}
		else
		{
			TutorialInfo.Instance.ActivateTutorial(5);
		}
	}

	public void GenerateDelayedQuests()
	{
		int delayedQuests = 0;
		foreach(var(questPath, amount) in QSSTracker.Instance.delayedQuestInfo)
		{
			for(int i = 0; i < amount; i++)
			{
				MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
				questHolder.AddChild(quest);
				quest.SpecificQuest(questPath);
				quest.isDelayed = true;
				delayedQuests++;
				quest.Position = new Vector2(150 + (delayedQuests * 175), 450);
				AddQuest(quest);
			}
		}
	}

	public void GenerateDelayedHelp()
	{
		int delayedQuests = 0;
		foreach(var(questPath, amount) in QSSTracker.Instance.delayedHelp)
		{
			for(int i = 0; i < amount.Count; i++)
			{
				GD.Print(questPath);
				MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
				questHolder.AddChild(quest);
				quest.SpecificQuest(questPath);
				quest.isDelayed = true;
				quest.NeedsWork(amount[i]);
				delayedQuests++;
				quest.Position = new Vector2(150 + (delayedQuests * 175), 450);
				AddQuest(quest);
			}
		}
	}

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
		heroNameDisplay.UpdateHeroPresence();
    }

	public void ChangeActiveHero(int change)
    {
		currentHero = change;
		heroDialouge.Text = "";
		heroName.Text = "";
		switch (change)
		{
			case 1:
				currentHeroSprite.ReplaceSprite("Knight");
				heroDialouge.AppendText("Provide me with your most challenging quest!");
				heroName.AppendText("[center]Allistrad von Leopoldo");
				break;
			case 2:
				currentHeroSprite.ReplaceSprite("Cleric");
				heroDialouge.AppendText("Where is my aid needed?");
				heroName.AppendText("[center]Rosalind Deacon");
				break;
			case 3:
				currentHeroSprite.ReplaceSprite("Mage");
				heroDialouge.AppendText("Who can I experim... HELP! Yeah help that's what I meant.");
				heroName.AppendText("[center]Lucy Fern");
				break;
			case 4:
				currentHeroSprite.ReplaceSprite("Monk");
				heroDialouge.AppendText("My fists hunger for victory!");
				heroName.AppendText("[center]Rashao Kahan");
				break;
			case 5:
				currentHeroSprite.ReplaceSprite("Ranger");
				heroDialouge.AppendText("What business do you have with the woods?");
				heroName.AppendText("[center]Thornton Breyer");
				break;
			case 6:
				currentHeroSprite.ReplaceSprite("Rogue");
				heroDialouge.AppendText("So… Whatcha need done?");
				heroName.AppendText("[center]Jack Decker");
				break;
			default:
				currentHeroSprite.ReplaceSprite("Phillip");
				heroDialouge.AppendText("Looks like everyone is out right now! You're gonna have to delay or toss out today's quests.");
				heroName.AppendText("[center]Phillip");
				break;
		}
		heroSelected = true;
    }

	public void PhillipNotHero()
	{
		heroDialouge.Text = "";
		heroDialouge.AppendText("I'm not a hero, man!");
	}

	public void HideActiveHero(){ currentHeroSprite.ConcealActiveHero(); }
}
