using Godot;
using System;

public partial class BuildingInteriorTutorial : Node2D
{
    public override void _Ready()
    {
        TutorialInfo.Instance.ActivateTutorial(2);
    }
}
