using Godot;
using System;
using System.Linq;

public partial class DayCount : RichTextLabel
{
    public override void _Ready()
    {
        this.Text = "";
        AppendText("[center][font_size=150]Day " + PlayerStats.Instance.DaysPassed);
        base._Ready();
    }

}
