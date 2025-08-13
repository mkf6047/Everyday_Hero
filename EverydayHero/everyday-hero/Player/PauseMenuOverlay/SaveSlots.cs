using Godot;
using System;

public partial class SaveSlots : Node2D
{
    public override void _Ready()
    {
        HideSaves();
    }
    public void HideSaves() { this.Hide(); }
    public void ShowSaves() { this.Show(); }
}
