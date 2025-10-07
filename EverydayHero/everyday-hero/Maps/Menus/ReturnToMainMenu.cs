using Godot;
using System;

public partial class ReturnToMainMenu : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
        base._Ready();
    }

    private void Clicked()
    {
        GetTree().ChangeSceneToFile("res://Maps/Menus/TitleScreen.tscn");
    }
}
