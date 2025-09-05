using Godot;
using System;

public partial class TutorialTrigger : Node2D
{
    [Export]
    int tutorialNum;
    TriggerArea area;
    public override void _Ready()
    {
        area = (TriggerArea)GetNode("TriggerArea");
        area.tutorialNum = this.tutorialNum;
    }

}
