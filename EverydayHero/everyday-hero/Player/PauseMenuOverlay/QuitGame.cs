using Godot;
using System;

public partial class QuitGame : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        GD.Print("it works");
        GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://Maps/Menus/TitleScreen.tscn");
    }
}
