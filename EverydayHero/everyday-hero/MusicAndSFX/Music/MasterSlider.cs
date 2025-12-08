using Godot;
using System;

public partial class MasterSlider : HSlider
{
    double prevVal = 50.0;

    public override void _Ready()
    {
        
    }

    public override void _Process(double delta)
    {
        if(prevVal != Value)
        {
            BackgroundNoise.Instance.SetMasterVolume((float)Value);
        }
    }

}
