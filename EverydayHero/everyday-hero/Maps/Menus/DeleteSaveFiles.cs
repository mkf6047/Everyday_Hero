using Godot;
using System;

public partial class DeleteSaveFiles : Button
{
    Node2D confirmDeletion;

    public override void _Ready()
    {
        confirmDeletion = (Node2D)GetNode("../ConfirmDeletion");
        confirmDeletion.Hide();
        this.Pressed += Clicked;
    }

    public void Clicked() {
        confirmDeletion.Show();
    }
}
