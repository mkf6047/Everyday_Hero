using Godot;
using System;

public partial class RevealAudioSettings : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        BackgroundNoise.Instance.Show();
    }

    public void MouseEnter()
    {
        this.Icon = GD.Load<Texture2D>("res://Sprites/Gear-Hover.png");
    }

    public void MouseExit()
    {
        this.Icon = GD.Load<Texture2D>("res://Sprites/Gear.png");
    }
}
