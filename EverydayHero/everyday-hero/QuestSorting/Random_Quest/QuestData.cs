using Godot;
using System;
using System.Collections.Generic;

public partial class QuestData : Node2D
{
    RichTextLabel questLabel, questValue, questDescription, questRank;
    Dictionary<string, string> questlist;
    //for^^:   quest name, quest type    
    Godot.Collections.Array<string> questsToChoose;     

    public override void _Ready()
    {
        questLabel = (RichTextLabel)GetNode("QuestLabel");
        questValue = (RichTextLabel)GetNode("QuestValue");
        questDescription = (RichTextLabel)GetNode("QuestDescription");
        questRank = (RichTextLabel)GetNode("QuestRank");
        questlist = new Dictionary<string, string>();
        questsToChoose = new Godot.Collections.Array<string>();

        using (var file = FileAccess.Open("res://QuestSorting/QuestInformation/ListOfQuests.txt", FileAccess.ModeFlags.Read))
        {
            string fileLine;
            string questType = "Misc";
            while (!file.EofReached())
            {
                fileLine = file.GetLine();
                if (fileLine != "") {
                    if (fileLine[0] == '-')
                    {
                        questType = fileLine.Substr(1, fileLine.Length - 1);
                        questType.Replace("-", "");
                    }
                    else
                    {
                        questlist.Add(fileLine, questType);
                        GD.Print(questlist[fileLine]);
                    }
                }
            }
        }

        string randomQuestType = "Misc";
        int randomNum = GD.RandRange(0, 3);
        switch (randomNum)
        {
            case 0: //collection
                randomQuestType = "Collection";
                break;
            case 1: //complex
                randomQuestType = "Complex";
                break;
            case 2: //conquest
                randomQuestType = "Conquest";
                break;
            case 3: //escort
                randomQuestType = "Escort";
                break;
            default:
                break;
        }

        foreach (KeyValuePair<string, string> entry in questlist)
        {
            if (entry.Value == randomQuestType)
            {
                questsToChoose.Add(entry.Key);
            }
        }
        randomNum = GD.RandRange(0, questsToChoose.Count - 1);
        if(randomNum < 0){ randomNum = 0; }
        GD.Print(randomNum);
        using (var file = FileAccess.Open("res://QuestSorting/QuestInformation/" + randomQuestType + "/" + questsToChoose[randomNum] + ".txt", FileAccess.ModeFlags.Read))
        {
            questLabel.AppendText("[center][color=black]" + file.GetLine());
            questDescription.AppendText("[color=black]" + file.GetLine());
            questRank.AppendText("[color=black]Rank: " + file.GetLine());
            string value = file.GetLine();
            questValue.AddText("" + value);
            MoveableQuest parent = (MoveableQuest)GetParent();
            parent.questReward = value.ToInt();
        }

        base._Ready();
    }
}
