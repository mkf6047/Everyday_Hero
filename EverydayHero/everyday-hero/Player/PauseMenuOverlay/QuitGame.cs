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
        GetTree().CallDeferred("change_scene_to_file", "res://Maps/Menus/TitleScreen.tscn");
    }
}
