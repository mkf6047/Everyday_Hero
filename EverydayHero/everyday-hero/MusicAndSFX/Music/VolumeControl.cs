using Godot;
using System;

public partial class VolumeControl : HSlider
{
    [Export]
    string busName;

    int busIndex;

    bool isfound = true;

    public override void _Ready()
    {
        busIndex = AudioServer.GetBusIndex(busName);
        if(busIndex == -1){ GD.Print("Audiobus " + busName + " not found."); isfound = false; return; }
        Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(busIndex));
        Connect("value_changed", new Callable(this, nameof(OnValueChanged)));
        using(var filepath = FileAccess.Open("user://" + busName + ".dat", FileAccess.ModeFlags.Read)){
            string val = filepath.GetLine();
            Value = double.Parse(val);
            AudioServer.SetBusVolumeDb(busIndex, Mathf.LinearToDb(float.Parse(val)));
        }
    }

    public virtual void OnValueChanged(float value)
    {
        AudioServer.SetBusVolumeDb(busIndex, Mathf.LinearToDb(value));
        using(var filepath = FileAccess.Open("user://" + busName + ".dat", FileAccess.ModeFlags.Write)){
            filepath.StoreLine("" + value);
        }
    }
}
