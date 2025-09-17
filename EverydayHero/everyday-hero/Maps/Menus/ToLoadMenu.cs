using Godot;
using System;

public partial class ToLoadMenu : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
        base._Ready();
    }

    private void Clicked()
    {
        GetTree().ChangeSceneToFile("res://Maps/Menus/LoadSave.tscn");
    }
}
