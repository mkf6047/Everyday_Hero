using Godot;
using System;

public partial class VolumeControl : HSlider
{
    [Export]
    string busName;

    int busIndex;

    public override void _Ready()
    {
        busIndex = AudioServer.GetBusIndex(busName);
        if(busIndex == -1){ GD.Print("Audiobus " + busName +" not found."); return; }
        Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(busIndex));
        Connect("value_changed", new Callable(this, nameof(OnValueChanged)));
    }

    public virtual void OnValueChanged(float value)
    {
        AudioServer.SetBusVolumeDb(busIndex, Mathf.LinearToDb(value));
    }
}
