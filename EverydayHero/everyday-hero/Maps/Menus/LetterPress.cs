using Godot;
using System;

public partial class LetterPress : Button
{
    [Export]
    string letter;
    bool isShiftActive = false;
    PlayerNameDecider name;
    public override void _Ready()
    {
        name = (PlayerNameDecider)GetNode("../../PlayerName");
        this.Pressed += Clicked;
    }

    public override void _Process(double delta)
    {
        if(isShiftActive != name.shiftActive && !((letter == "Back")||(letter == "Shift")))
        {
            if (isShiftActive)
            {
                this.Text = letter;
            }
            else
            {
                this.Text = letter.ToUpper();
            }
            isShiftActive = name.shiftActive;
        }
    }

    public void Clicked()
    {
        switch (letter)
        {
            case "Back":
                name.RemoveLetter();
                break;
            case "Shift":
                name.FlipShift();
                break;
            default:
                name.AddLetter(letter);
                break;
        }
    }
}
