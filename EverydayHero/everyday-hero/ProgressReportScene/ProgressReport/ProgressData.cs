using Godot;
using System;
using System.Collections.Generic;

public partial class ProgressData : Node2D
{
    RichTextLabel questProgress;   

    public override void _Ready()
    {
        questProgress = (RichTextLabel)GetNode("QuestProgress");

        base._Ready();
    }
}
