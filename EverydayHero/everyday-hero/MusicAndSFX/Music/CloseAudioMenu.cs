using Godot;
using System;

public partial class CloseAudioMenu : Button
{
    BackgroundNoise parent;
    public override void _Ready()
    {
        parent = (BackgroundNoise)GetNode("../../");
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        parent.Hide();
    }
}
