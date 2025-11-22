using Godot;
using System;

public partial class ScribbleEffect : Node2D
{
    AudioStreamPlayer output;
    bool isPlaying = false;
    double timer = 0.0;
    public override void _Ready()
    {
        output = (AudioStreamPlayer)GetNode("ScribbleSoundEffect");
        base._Ready();
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("Interact") || Input.IsActionJustPressed("cancel") || Input.IsActionJustPressed("mouse_click"))
        {
            timer = 0.0;
            output.Play();
            isPlaying = true;
        }
        if (isPlaying)
        {
            timer += delta;
            if(timer > 0.5)
            {
                output.Stop();
            }
        }
    }

}
