using Godot;
using System;

public partial class SfxSlider : HSlider
{
    float prevVal = 50.0f;
    
    public override void _Ready()
    {
        
    }

    public override void _Process(double delta)
    {
        if(prevVal != Value)
        {
            BackgroundNoise.Instance.SetSFXValue((float)Value);
        }
    }
}
