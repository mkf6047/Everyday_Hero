using Godot;
using System;
using System.Collections.Generic;

public partial class QuestData : Node2D
{
    RichTextLabel questLabel, questValue, questDescription, questRank, questDuration;
    Dictionary<string, string> questlist;
    //for^^:   quest name, quest type    
    Godot.Collections.Array<string> questsToChoose;

    MoveableQuest parent;

    public override void _Ready()
    {
        questLabel = (RichTextLabel)GetNode("QuestLabel");
        questValue = (RichTextLabel)GetNode("QuestValue");
        questDescription = (RichTextLabel)GetNode("QuestDescription");
        questRank = (RichTextLabel)GetNode("QuestRank");
        questDuration = (RichTextLabel)GetNode("QuestDuration");
        parent = (MoveableQuest)GetParent();
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
                        //GD.Print(questlist[fileLine]);
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
                this.parent.questType = "Collection";
                break;
            case 1: //complex
                randomQuestType = "Complex";
                this.parent.questType = "Complex";
                break;
            case 2: //conquest
                randomQuestType = "Conquest";
                this.parent.questType = "Conquest";
                break;
            case 3: //escort
                randomQuestType = "Escort";
                this.parent.questType = "Escort";
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
        //GD.Print(randomNum);
        using (var file = FileAccess.Open("res://QuestSorting/QuestInformation/" + randomQuestType + "/" + questsToChoose[randomNum] + ".txt", FileAccess.ModeFlags.Read))
        {
            string value = file.GetLine();
            questLabel.AppendText("[center][color=black]" + value);
            this.parent.questName = value;
            value = file.GetLine();
            questDescription.AppendText("[color=black][font_size=14]" + value);
            value = file.GetLine();
            questRank.AppendText("[color=black][font_size=13]Rank:");
            questRank.Newline();
            questRank.AppendText(value);
            this.parent.questRank = value;
            value = file.GetLine();
            questValue.AppendText("[color=black]" + value + "G");
            this.parent.questReward = int.Parse(value);
            value = file.GetLine();
            questDuration.AppendText("[font_size=13][color=black][center]Days:");
            questDuration.Newline();
            questDuration.AppendText(value);
            this.parent.questDuration = int.Parse(value);
            //GD.Print("quest information ported sucessfully.");
        }

        base._Ready();
    }

    public void SpecificQuest(string filepath)
    {
        using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Read))
        {
            string value = file.GetLine();
            questLabel.Text = "";
            questLabel.AppendText("[center][color=black]" + value);
            this.parent.questName = value;

            value = file.GetLine();
            questDescription.Text = "";
            questDescription.AppendText("[color=black][font_size=14]" + value);

            value = file.GetLine();
            questRank.Text = "";
            questRank.AppendText("[center][color=black][font_size=13]Rank:");
            questRank.Newline();
            questRank.AppendText(value);
            this.parent.questRank = value;

            value = file.GetLine();
            questValue.Text = "";
            questValue.AppendText("[center][color=black]" + value + "G");
            this.parent.questReward = int.Parse(value);

            value = file.GetLine();
            questDuration.Text = "";
            questDuration.AppendText("[center][font_size=13][color=black][center]Days:");
            questDuration.Newline();
            questDuration.AppendText(value);
            this.parent.questDuration = int.Parse(value);

            value = file.GetLine();
            this.parent.bestHeroes = value.Split(',');
            //GD.Print("quest information ported sucessfully.");
            if(filepath.Contains("Collection")){ this.parent.questType = "Collection";}
            if(filepath.Contains("Complex")){ this.parent.questType = "Complex";}
            if(filepath.Contains("Conquest")){ this.parent.questType = "Conquest";}
            if(filepath.Contains("Escort")){ this.parent.questType = "Escort";}
        }
    }
}
