using Godot;
using System;

public partial class ClosePartyInfo : Button
{
    Node2D parent;
    public override void _Ready()
    {
        parent = (Node2D)GetParent();
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        parent.Hide();
    }

}
