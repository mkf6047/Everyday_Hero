using Godot;
using System;

public partial class SaveComplete : Node2D
{
    bool saving = false;
    double timer = 0.0;

    public override void _Process(double delta)
    {
        if (saving && (timer > 1.5))
        {
            this.Hide();
            saving = false;
        }
        base._Process(delta);
    }
    public void Saved()
    {
        saving = true;
        timer = 0.0;
        this.Show();
    }
}
