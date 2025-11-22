using Godot;
using System;

public partial class SaveText : RichTextLabel
{
    [Export]
    public string saveFilepath;
    public override void _Ready()
    {
        base._Ready();
        ResetText();
    }

    public void ResetText()
    {
        string name = "-";
        string coins = "0";
        string playtime = "0";
        string rank = "Unemployed";
        using (var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read))
        {
            if (file.IsOpen())
            {
                name = file.GetLine();
                coins = file.GetLine();
                playtime = file.GetLine();
                rank = file.GetLine();
            }
            file.Close();
        }
        if (name == "-")
        {
            this.Text = "no data to load!";
            return;
        }
        this.Text ="";
        AppendText("[color=black]Name: " + name +
        "\nDays Passed: " + playtime +
        "\nRank: " + rank);
        
    }
}
