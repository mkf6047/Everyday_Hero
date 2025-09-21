using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class QuestSortingScene : Node2D
{
    Godot.Collections.Array<MoveableQuest> questStack = [];

    PackedScene questPreload = GD.Load<PackedScene>("res://QuestSorting/Random_Quest/RandomQuest.tscn");

    QssResults resultsDisplay;

    bool readyComplete, calculateOnce = false;

    int numofquest = 0;

    public override void _Ready()
    {
        int questsMade = 3;
        switch (PlayerStats.Instance.Rank)
        {
            case "SSS":
                questsMade = 15;
                break;
            case "SS":
                questsMade = 12;
                break;
            case "S":
                questsMade = 10;
                break;
            case "A":
                questsMade = 9;
                break;
            case "B":
                questsMade = 8;
                break;
            case "C":
                questsMade = 7;
                break;
            case "D":
                questsMade = 6;
                break;
            case "E":
                questsMade = 5;
                break;
            case "F":
                questsMade = 4;
                break;
            default:
                break;
        }
        for (int i = 0; i <= questsMade - 1; i++)
        {
            MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
            AddChild(quest);
            quest.Position = new Vector2((i + 1) * 200, 400);
            AddQuest(quest);
        }
        resultsDisplay = (QssResults)GetNode("QSSResults");
        QSSTracker.Instance.ResetCounts();
        readyComplete = true;
    }

    public override void _Process(double delta)
    {
        if ((numofquest <= 0) && readyComplete)
        {
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
