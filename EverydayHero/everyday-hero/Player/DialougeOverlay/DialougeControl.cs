using Godot;
using System;

public partial class DialougeControl : Node2D
{
    RichTextLabel textbox;
    RichTextLabel nameplate;
    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("./Textbox");
        nameplate = (RichTextLabel)GetNode("./Nameplate");
        this.Hide();
    }
    public void UpdateTextbox(string newText)
    {
        textbox.Text = "" + newText + "";
        this.Show();
    }
    public void UpdateNameplate(string newText)
    {
        nameplate.Text = "" + newText + "";
    }
    public void EndText()
    {
        this.Hide();
    }
}
