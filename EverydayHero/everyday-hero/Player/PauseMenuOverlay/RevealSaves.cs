using Godot;
using System;

public partial class RevealSaves : Button
{
    SaveSlots saveSlots;
    public override void _Ready()
    {
        saveSlots = (SaveSlots)GetNode("../SaveSlots");
        this.Pressed += Clicked;
        base._Ready();
    }
    public void Clicked()
    {
        saveSlots.ShowSaves();
    }
}
