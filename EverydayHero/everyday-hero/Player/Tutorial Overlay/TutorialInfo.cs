using Godot;
using System;
using System.Data.Common;

public partial class TutorialInfo : Node
{
    public static TutorialInfo Instance { get; private set; }
    private Godot.Collections.Array<Godot.Collections.Array<string>> tutorialLines;
    private double epsilon = 0.000001;
    private Vector2 previousMousePos;
    public int tutorialCount = 0;
    int currentLine = 0;
    public bool[] tutorialComplete = [false, false, false, false];      //add one per tutorial, position corresponding with tutorial lines
    private string[] tutorialDialougeFiles = [                  //make sure order of strings here corresponds with the order the related method appears in callTutorial method
        "res://Player/Tutorial Overlay/TutorialDialouge/Walking.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/ClickOnBuilding.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/InteractWithDesk.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/QSSIntro.txt"
    ];
    bool tutorialCondition = true;
    bool tutorialFound = false;
    double timer = 0.0;
    TutorialOverlay overlay;
    public override void _Ready()
    {
        tutorialLines = new Godot.Collections.Array<Godot.Collections.Array<string>>();
        // tutorialLines.Add(new Godot.Collections.Array<string>());
        // using (var file = FileAccess.Open("res://Player/Tutorial Overlay/TutorialMethods.txt", FileAccess.ModeFlags.Read))
        // {
        //     string content = "";
        //     while (!file.EofReached())
        //     {
        //         content = file.GetLine();
        //         tutorialLines[0].Add(content);
        //     }
        // }
        foreach (string a in tutorialDialougeFiles)
        {
            ReadLinesFromFile(a);
        }
        previousMousePos = new Vector2();

        Instance = this;    //this line must go last!!!!!
    }

    public override void _Process(double delta)
    {
        if (!tutorialComplete[tutorialCount])
        {
            CallTutorial(tutorialCount, delta);
        }
    }

    public void ReadLinesFromFile(string reading)
    {
        using (var file = FileAccess.Open(reading, FileAccess.ModeFlags.Read))
        {
            string content = "";
            Godot.Collections.Array<string> lines = new Godot.Collections.Array<string>();
            while (!file.EofReached())
            {
                content = file.GetLine();
                lines.Add(content);
            }
            tutorialLines.Add(lines);
        }
    }

    #region TutorialTemplate
    private void Template(double delta = 0.0)   //change from private to public
    {
        if (tutorialComplete[0])       //replace 0 with actual corresponding int.
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 5.0 && tutorialCondition)
            {
                tutorialComplete[tutorialCount] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            //tutorial processing goes here!!!!
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("ReplaceThisTextWithTutorialDialouge");
            tutorialCondition = false;
        }
    }
    #endregion

    public void Walking(double delta = 0.0)    //walking tutorial
    {
        if (tutorialComplete[0])                //walking corresponds to 0 in list.
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 2.0 && tutorialCondition)
            {
                tutorialComplete[0] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            if (Input.IsActionJustPressed("up") || Input.IsActionJustPressed("down") || Input.IsActionJustPressed("left") || Input.IsActionJustPressed("right"))
            {
                tutorialCondition = true;
            }
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("Use the 'WASD' keys or the arrow keys to move!");
            tutorialCondition = false;
        }
        else if (Input.IsActionJustPressed(""))
        {
            
        }
    }
    public void ClickOnBuilding(double delta = 0.0)   //change from private to public
    {
        if (tutorialComplete[1])       //replace 0 with actual corresponding int.
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 2.0 && tutorialCondition)
            {
                tutorialComplete[1] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            if (previousMousePos != GetViewport().GetMousePosition()) {
                tutorialCondition = true;
            }
            previousMousePos = GetViewport().GetMousePosition();
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("Hover your mouse over the building you want to enter!");
            tutorialCondition = false;
        }
    }
    public void InteractWithDesk(double delta = 0.0)
    {
        if (tutorialComplete[2])       
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 2.0 && tutorialCondition)
            {
                tutorialComplete[2] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            //tutorial processing goes here!!!!
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("Click and Hold to drag a quest over to one of the corresponding bins!");
            tutorialCondition = false;
        }
    }
    public void QSSIntro(double delta = 0.0)   //change from private to public
    {
        if (tutorialComplete[3])       //replace 0 with actual corresponding int.
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 2.0 && tutorialCondition)
            {
                tutorialComplete[3] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            //tutorial processing goes here!!!!
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText("Click and Hold to drag a quest over to one of the corresponding bins!");
            tutorialCondition = false;
        }
    }

    //insert new tutorials here!!!!!

    public void ActivateTutorial(int tutorialNum)
    {
        var tutOver = GetTree().GetFirstNodeInGroup("TutorialNode");
        if (tutOver is TutorialOverlay incomingOverlay)
        {
            overlay = incomingOverlay;
            tutorialFound = true;
        }
        else if(tutOver is null){ return; }
        else { GD.Print("Unable to load tutorial"); return; }
        int size = tutorialLines.Count;
        if ((tutorialNum >= 0) && (tutorialNum <= (size - 1)))
        {
            tutorialCount = tutorialNum;
            CallTutorial(tutorialCount);
        }
    }   //do not put any tutorials after this function

    public void CallTutorial(int tutorial, double delta = 0.0)
    {
        var tutOver = GetTree().GetFirstNodeInGroup("TutorialNode");
        if (tutOver is TutorialOverlay incomingOverlay)
        {
            overlay = incomingOverlay;
        }
        else if(tutOver is null){ return; }
        else { GD.Print("Unable to load tutorial"); return; }
        switch (tutorial)
        {
            //copy below template to add a tutorial to the list.
            // case -1:             //change to correct case
            //     Template(delta); //change this to the correct method
            //     break;
            case 0:
                Walking(delta);
                break;
            case 1:
                previousMousePos = GetViewport().GetMousePosition();
                ClickOnBuilding(delta);
                break;
            case 2:
                QSSIntro(delta);
                break;
            case 3:
                QSSIntro(delta);
                break;
            default:
                GD.Print("Invalid Tutorial Number.");
                break;
        }
    }
}
