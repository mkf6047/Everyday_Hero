using Godot;
using System;

public partial class BuildingName : Node2D
{
    RichTextLabel textbox;

    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("Textbox");
        HideThis();
    }

    public void UpdateText(string text)
    {
        textbox.Text = "[center]" + text;
        this.Show();
    }

    public void HideThis()
    {
        this.Hide();
    }
}
