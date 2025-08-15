using Godot;
using System;

public partial class MenuInfo : Node2D
{
    RichTextLabel menuInfoText;
    public override void _Ready()
    {
        menuInfoText = (RichTextLabel)GetNode("MenuInfoText");
        base._Ready();
    }
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("cancel"))
        {
            menuInfoText.Clear();
            menuInfoText.AddText("Playtime: " + PlayerStats.Instance.Playtime);
            menuInfoText.Newline();
            menuInfoText.AddText("Coins: " + PlayerStats.Instance.Coins);
            menuInfoText.Newline();
            menuInfoText.AddText("Rank: " + PlayerStats.Instance.Rank);
            menuInfoText.Newline();
        }
        base._Process(delta);
    }
}
