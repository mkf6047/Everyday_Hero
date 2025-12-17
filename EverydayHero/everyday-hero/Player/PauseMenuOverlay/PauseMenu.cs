using Godot;
using System;

public partial class PauseMenu : Control
{
    bool isMenuOpen = false;
    double timer = 0.0;
    PlayerFunctions playerFunctions;
    public override void _Ready()
    {
        this.Hide();
        //playerFunctions = (PlayerFunctions)GetNode("../../../");
        //base._Ready();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("cancel"))
        {
            if (isMenuOpen)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
        base._Process(delta);
    }
    
    public void OpenMenu()
    {
        isMenuOpen = false;
        this.Hide();
        GetTree().Paused = false;
    }

    public void CloseMenu()
    {
        isMenuOpen = true;
        GetTree().Paused = true;
        this.Show();
    }
}
