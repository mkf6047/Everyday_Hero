using Godot;
using System;

public partial class PauseMenu : Control
{
    bool isMenuOpen = false;

    public override void _Ready()
    {
        this.Hide();
        base._Ready();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("cancel"))
        {
            if (isMenuOpen)
            {
                this.Hide();
                GetTree().Paused = false;
            }
            else
            {
                GetTree().Paused = true;
                this.Show();
            }
        }
        base._Process(delta);
    }

}
