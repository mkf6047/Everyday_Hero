using Godot;
using System;

public partial class No : Button
{
    Node2D confirmDelete;
    public override void _Ready()
    {
        confirmDelete = (Node2D)GetParent();
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        confirmDelete.Hide();
    }
}
