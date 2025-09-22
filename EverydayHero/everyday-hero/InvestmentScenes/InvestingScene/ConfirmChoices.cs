using Godot;
using System;

public partial class ConfirmChoices : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        GetTree().ChangeSceneToFile("");
    }
}
