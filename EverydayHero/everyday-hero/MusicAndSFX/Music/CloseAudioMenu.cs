using Godot;
using System;

public partial class CloseAudioMenu : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        BackgroundNoise.Instance.Hide();
    }
}
