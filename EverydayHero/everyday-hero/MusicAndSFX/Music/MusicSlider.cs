using Godot;
using System;

public partial class MusicSlider : HSlider
{
    float prevVal = 50.0f;
    
    public override void _Ready()
    {
        
    }

    public override void _Process(double delta)
    {
        if(prevVal != Value)
        {
            BackgroundNoise.Instance.SetMusicValue((float)Value);
        }
    }
}
