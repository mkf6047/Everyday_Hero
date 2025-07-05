using Godot;
using System;

public partial class DialougeControl : Node2D
{
    RichTextLabel textbox;
    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("./Textbox");
    }
    public void UpdateTextbox(string newText)
    {
        textbox.Text = "" + newText + "";
    }
}
