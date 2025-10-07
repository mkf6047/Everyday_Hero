using Godot;
using System;

public partial class MainSceneTutorial : Node2D
{
    public override void _Ready()
    {
        TutorialInfo.Instance.ActivateTutorial(1);
    }

}
