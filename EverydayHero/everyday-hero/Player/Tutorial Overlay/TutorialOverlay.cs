using Godot;
using System;

public partial class TutorialOverlay : Control
{
    RichTextLabel textbox, nameplate;

    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("Textbox");
        nameplate = (RichTextLabel)GetNode("Nameplate");
        HideOverlay();
    }
    public void UpdateText(string incomingText, string incomingName)
    {
        textbox.Text = incomingText;
        nameplate.Text = incomingName;
        ShowOverlay();
    }
    public void HideOverlay(){ this.Hide(); }
    public void ShowOverlay(){ this.Show(); }
}
