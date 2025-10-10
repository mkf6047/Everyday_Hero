using Godot;
using System;

public partial class ToNewGame : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
        base._Ready();
    }

    private void Clicked()
    {
        GetTree().ChangeSceneToFile("res://Maps/Menus/NamingPlayer.tscn");
    }
}
