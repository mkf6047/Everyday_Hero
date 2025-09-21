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

    public void RevealResults()
    {

        this.Show();
    }
    
}
