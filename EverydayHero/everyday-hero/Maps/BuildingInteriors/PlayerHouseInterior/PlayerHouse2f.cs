using Godot;
using System;

public partial class PlayerHouse2f : Node2D
{
    public override void _Ready()
    {
        TutorialInfo.Instance.ActivateTutorial(0);
    }
}
