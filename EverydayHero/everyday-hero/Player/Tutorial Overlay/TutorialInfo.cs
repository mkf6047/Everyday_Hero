using Godot;
using System;

public partial class TutorialInfo : Node
{
    public static TutorialInfo Instance { get; private set; }
    private Godot.Collections.Array<string> tutorialLines;
    public int tutorialCount = 0;
    bool tutorialComplete = true;
    bool tutorialCondition = true;
    double timer = 0.0;
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
        if (!tutorialComplete)
        {
            this.CallDeferred(tutorialLines[tutorialCount], delta);
        }
    }

    public void ActivateTutorial(int tutorialNum)
    {
        int size = tutorialLines.Count;
        if ((tutorialNum >= 0) && (tutorialNum <= (size - 1)))
        {
            tutorialCount = tutorialNum;
            this.Call(tutorialLines[tutorialCount]);
        }
    }

    private void Walking(double delta = 0.0)
    {
        if (tutorialComplete)
        {
            tutorialCondition = false;
            tutorialComplete = false;
        }
        else
        {
            timer += delta;
            if (timer > 10.0 && tutorialCondition)
            {
                tutorialComplete = true;
                return;
            }
            if (Input.IsActionJustPressed("up") || Input.IsActionJustPressed("down") || Input.IsActionJustPressed("left") || Input.IsActionJustPressed("right"))
            {
                tutorialCondition = true;
            }
        }
    }

}
