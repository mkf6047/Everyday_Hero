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
        questerName.AppendText("[center][color=black]" + name);
    }
    
    public void UpdateProgress(string condition)
    {
        questerName.Text = "";
        questerName.AppendText("[center][color=black]");
        switch (condition)
        {
            default:
                break;
        }
    }
}
