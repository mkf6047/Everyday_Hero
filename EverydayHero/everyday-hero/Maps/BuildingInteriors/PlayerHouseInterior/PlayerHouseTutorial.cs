using Godot;
using System;

public partial class PlayerHouseTutorial : Node2D
{
    public override void _Ready()
    {
        TutorialInfo.Instance.ActivateTutorial(4);
    }

}
