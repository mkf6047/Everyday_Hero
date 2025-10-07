using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class QuestSortingScene : Node2D
{
    Godot.Collections.Array<MoveableQuest> questStack = [];

    PackedScene questPreload = GD.Load<PackedScene>("res://QuestSorting/Random_Quest/RandomQuest.tscn");

    QssResults resultsDisplay;

    ClassAndRank displayClassRank;

    

    bool readyComplete, calculateOnce, allPartiesSorted = false;

    int numofquest = 0;
    int partiesApplying, currentParty = 0;

    public override void _Ready()
    {
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
        resultsDisplay = (QssResults)GetNode("QSSResults");
        displayClassRank = (ClassAndRank)GetNode("PartyInformation/Class&Rank");
        GenerateQuests();
        displayClassRank.LoadNextParty(currentParty);
        QSSTracker.Instance.ResetCounts();
        readyComplete = true;
        TutorialInfo.Instance.ActivateTutorial(3);
    }

    public override void _Process(double delta)
    {
        if ((numofquest <= 0) && readyComplete && allPartiesSorted)
        {
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
        if ((numofquest <= 0) && (currentParty >= (partiesApplying - 1)) && readyComplete)
        {
            currentParty++;
            GenerateQuests();
            displayClassRank.LoadNextParty(currentParty);
        }
    }

    public void GenerateQuests()
    {
        for (int i = 0; i <= 3; i++)
        {
            MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
            AddChild(quest);
            quest.Position = new Vector2((i + 1) * 200, 300);
            AddQuest(quest);
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
        RemoveChild(quest);
        quest.QueueFree();
        numofquest--;
    }
}
