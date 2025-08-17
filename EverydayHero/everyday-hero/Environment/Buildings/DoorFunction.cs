using Godot;
using System;

public partial class DoorFunction : Area2D
{

    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            PlayerStats.Instance.isInside = true;
            PlayerStats.Instance.playerLocationInterior.Y -= 20;
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/BuildingInteriors/BuildingInterior.tscn");
        }
        catch
        {
            GD.PrintErr("Door just collided with something other than a Player.");
        }
        
    }
}
