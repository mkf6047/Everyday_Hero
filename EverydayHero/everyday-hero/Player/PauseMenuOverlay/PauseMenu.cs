using Godot;
using System;

public partial class PauseMenu : Control
{
    bool isMenuOpen = false;
    PlayerFunctions playerFunctions;
    public override void _Ready()
    {
        this.Hide();
        playerFunctions = (PlayerFunctions)GetNode("../../");
        base._Ready();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("cancel") && (!playerFunctions.IsBusy))
        {
            if (isMenuOpen)
            {
                isMenuOpen = false;
                this.Hide();
                GetTree().Paused = false;
            }
            else
            {
                isMenuOpen = true;
                GetTree().Paused = true;
                this.Show();
            }
        }
        base._Process(delta);
    }

}
