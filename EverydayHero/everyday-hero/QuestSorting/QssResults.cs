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
    public override void _Process(double delta)
    {
        if (isActive)
        {
            if (Input.IsActionJustPressed("Interact"))
            {
                GetTree().CallDeferred("change_scene_to_file", "res://Maps/BuildingInteriors/BuildingInterior.tscn");
            }
        }
    }

    public void RevealResults(string resultString)
    {
        string[] brokenResults = resultString.Split(';');
        resultsScreen.Text = "[center]Quests Accepted: " + brokenResults[0];
        resultsScreen.Newline();
        resultsScreen.Text += "Quests Delayed: " + brokenResults[1];
        resultsScreen.Newline();
        resultsScreen.Text += "Quests Rejected: " + brokenResults[2];
        resultsScreen.Newline();
        resultsScreen.Text += "Income: " + brokenResults[3];
        resultsScreen.Newline();
        this.Show();
    }
    
}
