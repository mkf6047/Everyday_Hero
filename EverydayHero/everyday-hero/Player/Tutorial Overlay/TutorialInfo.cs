using Godot;
using System;

public partial class TutorialInfo : Node
{
    public static TutorialInfo Instance { get; private set; }
    private Godot.Collections.Array<string> tutorialLines;
    private double epsilon = 0.000001;
    public int tutorialCount = 0;
    bool[] tutorialComplete = [false, false];   //add one per tutorial, position corresponding with tutorial lines
    bool tutorialCondition = true;
    double timer = 0.0;
    TutorialOverlay overlay;
    public override void _Ready()
    {
        tutorialLines = new Godot.Collections.Array<string>();
        using (var file = FileAccess.Open("res://Player/Tutorial Overlay/TutorialMethods.txt", FileAccess.ModeFlags.Read))
        {
            string content = "";
            while (!file.EofReached())
            {
                content = file.GetLine();
                tutorialLines.Add(content);
            }
        }

        Instance = this;    //this line must go last!!!!!
    }

    public override void _Process(double delta)
    {
        if (!tutorialComplete[tutorialCount])
        {
            this.CallDeferred(tutorialLines[tutorialCount], delta);
        }
    }

    public void ActivateTutorial(int tutorialNum)
    {
        var tutOver = GetTree().GetFirstNodeInGroup("TutorialNode");
        if (tutOver is TutorialOverlay incomingOverlay)
        {
            overlay = incomingOverlay;
        }
        else { GD.Print("Unable to load tutorial"); return; }
        int size = tutorialLines.Count;
        if ((tutorialNum >= 0) && (tutorialNum <= (size - 1)))
        {
            tutorialCount = tutorialNum;
            this.Call(tutorialLines[tutorialCount]);
        }
    }

    #region TutorialTemplate
    private void Template(double delta = 0.0)
    {
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("ReplaceThisTextWithTutorialDialouge");
        }
        if (tutorialComplete[tutorialCount])
        {
            tutorialCondition = false;
            tutorialComplete[tutorialCount] = false;
        }
        else
        {
            timer += delta;
            if (timer > 10.0 && tutorialCondition)
            {
                tutorialComplete[tutorialCount] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            //tutorial processing goes here!!!!
        }
    }
    #endregion

    private void Walking(double delta = 0.0)    //walking tutorial
    {
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("Use the 'WASD' keys or the arrow keys to move!");
        }
        if (tutorialComplete[tutorialCount])
        {
            tutorialCondition = false;
            tutorialComplete[tutorialCount] = false;
        }
        else
        {
            timer += delta;
            if (timer > 10.0 && tutorialCondition)
            {
                tutorialComplete[tutorialCount] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            if (Input.IsActionJustPressed("up") || Input.IsActionJustPressed("down") || Input.IsActionJustPressed("left") || Input.IsActionJustPressed("right"))
            {
                tutorialCondition = true;
            }
        }
    }
}
