using Godot;
using System;

public partial class CloseMenu : Button
{
    PauseMenu parent;

    public override void _Ready()
    {
        parent = (PauseMenu)GetParent();
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        parent.CloseMenu();
    }
}
