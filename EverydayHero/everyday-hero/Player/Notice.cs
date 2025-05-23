using Godot;
using System;

public partial class Notice : Sprite2D
{

    public override void _Ready()
    {
        base._Ready();
        this.Hide();
    }

    public void ShowNotice()
    {
        this.Show();
    }

    public void HideNotice()
    {
        this.Hide();
    }
}
