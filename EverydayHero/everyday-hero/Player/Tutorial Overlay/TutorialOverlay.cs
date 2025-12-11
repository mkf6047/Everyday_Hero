using Godot;
using System;

public partial class TutorialOverlay : Control
{
    RichTextLabel textbox, nameplate;
    Sprite2D speakerSprite;

    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("Textbox");
        nameplate = (RichTextLabel)GetNode("Nameplate");
        speakerSprite = (Sprite2D)GetNode("SpeakerSprite");
        HideOverlay();
    }
    public void UpdateText(string incomingText, string incomingName)
    {
        textbox.Text = incomingText;
        nameplate.Text = "";
        nameplate.AppendText(incomingName);
        if(incomingName == "[center]Manager Phillip"){ speakerSprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Manager-Philip.png"); }
        else{ speakerSprite.Texture = GD.Load<Texture2D>("res://Sprites/EmptySprite.png"); }
        ShowOverlay();
    }
    public void HideOverlay(){ this.Hide(); }
    public void ShowOverlay(){ this.Show(); }
}
