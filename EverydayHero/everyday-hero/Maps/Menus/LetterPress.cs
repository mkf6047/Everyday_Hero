using Godot;
using System;

public partial class LetterPress : Button
{
    [Export]
    string letter;

    PlayerNameDecider name;
    public override void _Ready()
    {
        name = (PlayerNameDecider)GetNode("../../PlayerName");
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        switch (letter)
        {
            case "Back":
            case "Shift":
            default:
                break;
        }
    }
}
