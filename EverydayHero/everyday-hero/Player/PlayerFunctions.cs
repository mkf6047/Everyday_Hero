using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerFunctions : Node2D
{
    DialougeControl dialouge;
    int dialougeLine = 0;
    List<string> lines;
    string dialougeNameplate;
    bool talking = false;

    public override void _Ready()
    {
        dialouge = (DialougeControl)GetNode("Overlays/DialougeOverlay");
    }
    public override void _Process(double delta)
    {
        if (talking)
        {
            if (Input.IsActionJustPressed("Interact"))
            {
                AdvanceTextbox();
            }
        }
    }

    public void AdvanceTextbox()
    {
        if (dialougeLine >= lines.Count)
        {
            EndTextbox();
            return;
        }
        dialouge.UpdateTextbox(lines[dialougeLine]);
        dialougeLine++;
    }

    public void LoadText(string filepath)
    {
        using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Read))
        {
            if (file != null)
            {
                string fileText = file.GetAsText();
                int split = fileText.IndexOf('^');
                dialougeNameplate = fileText.Substr(0, split + 1);
                fileText.Remove(0, split + 1);
                while ((split = fileText.IndexOf('^')) > 0)
                {
                    lines.Add(fileText.Substr(0, split + 1));
                    fileText.Remove(0, split + 1);
                }
                lines.Add(fileText);
            }
            else
            {
                return;
            }
        }
        AdvanceTextbox();
        dialouge.UpdateNameplate(dialougeNameplate);
        dialouge.BeginText();
        talking = true;
    }

    public void EndTextbox()
    {
        dialouge.EndText();
        talking = false;
    }
}
