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
    string speakerName = "";
    public bool[] tutorialComplete = [true, false, false, false, false, false];      //add one per tutorial, position corresponding with tutorial lines
    private string[] tutorialDialougeFiles = [                  //make sure order of strings here corresponds with the order the related method appears in callTutorial method
        "res://Player/Tutorial Overlay/TutorialDialouge/Walking.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/ClickOnBuilding.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/InteractWithDesk.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/QSSIntro.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/ProgressReportIntro.txt",
        "res://Player/Tutorial Overlay/TutorialDialouge/ReturningHeroes.txt"
    ];
    public bool tutorialCondition, canComplete = true;
    bool tutorialFound = false;
    double timer = 0.0;
    TutorialOverlay overlay;
    public override void _Ready()
    {
        tutorialLines = new Godot.Collections.Array<Godot.Collections.Array<string>>();
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
            lines.RemoveAt(lines.Count - 1);    //last line guranteed to be empty due to how textfiles are saved via godot, removed for convenience.
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
            if (timer > 2.0 && tutorialCondition)
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
            overlay.UpdateText(tutorialLines[0][0], "");    //replace first 0 with tutorial index
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if (currentLine <= tutorialLines[0].Count - 1)
            {
                overlay.UpdateText(tutorialLines[0][currentLine], "");
                if(currentLine == tutorialLines[1].Count - 1){ canComplete = true; }
            }
            else{ canComplete = true; }
        }
    }
    #endregion

    public void Walking(double delta = 0.0)    //call with ActivateTutorial(0)
    {
        if (tutorialComplete[0])               //walking corresponds to 0 in list.
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
            if ((Input.IsActionJustPressed("up") || Input.IsActionJustPressed("down") || Input.IsActionJustPressed("left") || Input.IsActionJustPressed("right")) && canComplete)
            {
                tutorialCondition = true;
            }
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText(tutorialLines[0][0], PlayerStats.Instance.PlayerName);
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if (currentLine <= tutorialLines[0].Count - 1)
            {
                overlay.UpdateText(tutorialLines[0][currentLine], PlayerStats.Instance.PlayerName);
                if(currentLine == tutorialLines[1].Count - 1){ canComplete = true; }
            }
            else{ canComplete = true; }
        }
    }
    public void ClickOnBuilding(double delta = 0.0)  //call with ActivateTutorial(1)
    {
        if (tutorialComplete[1])       
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 1.0 && tutorialCondition)
            {
                tutorialComplete[1] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            if (previousMousePos != GetViewport().GetMousePosition() && canComplete) {
                tutorialCondition = true;
            }
            previousMousePos = GetViewport().GetMousePosition();
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText(tutorialLines[1][0], PlayerStats.Instance.PlayerName);
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if (currentLine <= tutorialLines[1].Count - 1)
            {
                overlay.UpdateText(tutorialLines[1][currentLine], PlayerStats.Instance.PlayerName);
                if(currentLine == tutorialLines[1].Count - 1){ canComplete = true; }
            }
            else { canComplete = true; }
        }
    }
    public void InteractWithDesk(double delta = 0.0)    //call with ActivateTutorial(2)
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
            if (Input.IsActionJustPressed("Interact") && canComplete)
            {
                tutorialCondition = true;
            }
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText(tutorialLines[2][0], "Phillip");
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if (currentLine <= tutorialLines[2].Count - 1)
            {
                overlay.UpdateText(tutorialLines[2][currentLine], "Phillip");
                if(currentLine == tutorialLines[1].Count - 1){ canComplete = true; }
            }
            else{ canComplete = true; }
        }
    }
    public void QSSIntro(double delta = 0.0)   //call with ActivateTutorial(3)
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
                currentLine = 0;
                overlay.HideOverlay();
                return;
            }
            if(canComplete && Input.IsActionPressed("Interact")){ tutorialCondition = true; }
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            speakerName = "[center]Manager Phillip";
            overlay.UpdateText(tutorialLines[3][0], speakerName);
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if((currentLine == 7) || (currentLine == 6) || (currentLine >= 14)){ speakerName = "[center]" + PlayerStats.Instance.PlayerName;}
            else{ speakerName = "[center]Manager Phillip";}
            if (currentLine <= tutorialLines[3].Count - 1)
            {
                overlay.UpdateText(tutorialLines[3][currentLine], speakerName);
                if(currentLine == tutorialLines[3].Count - 1){ canComplete = true; }
            }
            else{ canComplete = true; }
        }
    }
    private void SaveGame(double delta = 0.0)   //call with ActivateTutorial(4)
    {
        if (tutorialComplete[4])       //replace 0 with actual corresponding int.
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 2.0 && tutorialCondition)
            {
                tutorialComplete[tutorialCount] = true;
                timer = 0.0;
                overlay.HideOverlay();
                return;
            }
            if(canComplete && Input.IsActionJustPressed("Interact")){ tutorialCondition = true; }
            //tutorial processing goes here!!!!
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText(tutorialLines[4][0], "[center]Manager Phillip");    //replace first 0 with tutorial index
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if(currentLine >= 3){ speakerName = "[center]" + PlayerStats.Instance.PlayerName;}
            else{ speakerName = "[center]Manager Phillip";}
            if (currentLine <= tutorialLines[4].Count - 1)
            {
                overlay.UpdateText(tutorialLines[4][currentLine], speakerName);
                if(currentLine == tutorialLines[4].Count - 1){ canComplete = true; }
            }
            else{ canComplete = true; }
        }
    }
    public void ProgressReportIntro(double delta = 0.0)   //call with ActivateTutorial(5)
    {
        if (tutorialComplete[5])       //replace 0 with actual corresponding int.
        {
            return;
        }
        else
        {
            timer += delta;
            if (timer > 2.0 && tutorialCondition)
            {
                tutorialComplete[5] = true;
                timer = 0.0;
                currentLine = 0;
                overlay.HideOverlay();
                return;
            }
            if(canComplete && Input.IsActionJustPressed("Interact")){ tutorialCondition = true; }
        }
        if (Math.Abs(delta - 0.0) < epsilon)
        {
            overlay.UpdateText(tutorialLines[5][0], "[center]Manager Phillip");
            currentLine = 0;
            tutorialCondition = false;
            canComplete = false;
        }
        else if (Input.IsActionJustPressed("Interact"))
        {
            currentLine++;
            if (currentLine <= tutorialLines[5].Count - 1)
            {
                overlay.UpdateText(tutorialLines[5][currentLine], "[center]Manager Phillip");
                if(currentLine == tutorialLines[5].Count - 1){ canComplete = true; }
            }
            else{ canComplete = true; }
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
        else if(tutOver is null){ GD.Print("Cannot find overlay"); return; }
        else { GD.Print("Unable to load tutorial"); return; }
        int size = tutorialLines.Count;
        if ((tutorialNum >= 0) && (tutorialNum <= (size - 1)))
        {
            tutorialCount = tutorialNum;
            canComplete = false; tutorialCondition = false;
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
        else if(tutOver is null){ GD.Print("Cannot find overlay"); return; }
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
                InteractWithDesk(delta);
                break;
            case 3:
                QSSIntro(delta);
                break;
            case 4:
                SaveGame(delta);
                break;
            case 5:
                ProgressReportIntro(delta);
                break;
            default:
                GD.Print("Invalid Tutorial Number.");
                break;
        }
    }
}
