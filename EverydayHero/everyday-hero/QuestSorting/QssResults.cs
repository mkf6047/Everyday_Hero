using Godot;
using System;

public partial class QssResults : Node2D
{
    RichTextLabel resultsScreen;
    bool isActive = false;

    public override void _Ready()
    {
        resultsScreen = (RichTextLabel)GetNode("Textbox");
        this.Hide();
        base._Ready();
    }

    public void RevealResults(string resultString)
    {
        string[] brokenResults = resultString.Split(';');
        resultsScreen.Text = "";
        resultsScreen.Newline();
        resultsScreen.AppendText("[center][font_size=30]Quests Accepted: " + brokenResults[0]);
        resultsScreen.Newline();
        resultsScreen.AppendText("Quests Delayed: " + brokenResults[1]);
        resultsScreen.Newline();
        resultsScreen.AppendText("Quests Rejected: " + brokenResults[2]);
        resultsScreen.Newline();
        //resultsScreen.AppendText("Income: " + brokenResults[3]);
        //resultsScreen.Newline();
        this.Show();
    }
    
}
