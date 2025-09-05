using Godot;
using System;

public partial class TriggerArea : Area2D
{
    public int tutorialNum = -1;

    public virtual void OnArea2DBodyEntered()
    {
        if (tutorialNum < 0) { return; }
        TutorialInfo.Instance.ActivateTutorial(tutorialNum);
    }

    public virtual void OnArea2DBodyExited()
    {
        if(tutorialNum < 0){ return; }
    }
}
