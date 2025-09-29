using Godot;
using System;

public partial class AreaNoticeOverlay : Node2D
{
    RichTextLabel textbox;
    double timer = 0.0;
    bool isHidden = false;
    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("NewArea");
        textbox.Text = "[center]" + GetTree().CurrentScene.Name;
    }
    public override void _Process(double delta)
    {
        if (timer < 3.0)
        {
            timer += delta;
            return;
        }
        if(!isHidden){ this.Hide(); return; }
    }

}
