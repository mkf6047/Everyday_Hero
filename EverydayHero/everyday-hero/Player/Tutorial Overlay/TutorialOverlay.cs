using Godot;
using System;

public partial class TutorialOverlay : Control
{
    RichTextLabel textbox;

    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("Textbox");
        HideOverlay();
    }
    public void UpdateText(string incomingText)
    {
        textbox.Text = incomingText;
        ShowOverlay();
    }
    public void HideOverlay(){ this.Hide(); }
    public void ShowOverlay(){ this.Show(); }
}
