using Godot;
using System;
using System.Collections.Generic;

public partial class ProgressData : Node2D
{
    RichTextLabel questProgress, questerName;

    public override void _Ready()
    {
        questProgress = (RichTextLabel)GetNode("QuestProgress");
        questerName = (RichTextLabel)GetNode("QuesterName");
    }

    public void UpdateName(string name)
    {
        questerName.Text = "";
        questerName.AppendText("[center][color=black][font_size=14]" + name);
    }
    
    public void UpdateProgress(int hero, int failChance)
    {
        bool passFail = false; //starts off not passing
        Random rand = new Random();
        int randNum = rand.Next(1, 101);
        if(randNum <= failChance){ passFail = true; }
        string updateText = "";
        questProgress.Text = "";
        questProgress.AppendText("[center][color=black]");
        switch (hero)
        {
            case 0:     //Allistrad
                if(passFail){ updateText = "Nothing a worthy hero like ME can't handle"; }
                else{ updateText = "Whoof… This is harder than I thought"; }
                break;
            case 1:     //rosalind
                if(passFail){ updateText = "Oh thank the heavens! Everything went well."; }
                else{ updateText = "Do my prayers go unanswered?"; }
                break;
            case 2:     //lucy
                if(passFail){ updateText = "This has been a very enlightening experience"; }
                else{ updateText = "Note: the blast radius is large and I am a squishy mage"; }
                break;
            case 3:     //rashao
                if(passFail){ updateText = "I haven’t lost my touch at all!"; }
                else{ updateText = "I might be getting too old for this"; }
                break;
            case 4:     //thornton
                if(passFail){ updateText = "Mother Earth has blessed my efforts"; }
                else{ updateText = "The forest is angry today"; }
                break;
            case 5:     //jack
                if(passFail){ updateText = "Its been done"; }
                else{ updateText = "..... Things didn’t go well"; }
                break;
            default:
                if(passFail){ updateText = "[i]*the note is covered in splotches of ink.*"; }
                else{ updateText = "[i]*the note is covered in splotches of blood.*"; }
                break;
        }
        questProgress.AppendText(updateText);
    }
}
