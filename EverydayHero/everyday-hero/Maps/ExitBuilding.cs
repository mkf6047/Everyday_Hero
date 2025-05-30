using Godot;
using System;

public partial class ExitBuilding : Area2D
{

    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            GetTree().ChangeSceneToFile("res://Environment/Buildings/Building Template.tscn");
        }
        catch
        {
            GD.PrintErr("Door just collided with something other than a Player.");
        }
        
    }
}
