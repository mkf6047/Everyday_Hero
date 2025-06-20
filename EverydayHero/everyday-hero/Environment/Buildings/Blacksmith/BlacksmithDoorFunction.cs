using Godot;
using System;

public partial class BlacksmithDoorFunction : Area2D
{

    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/BuildingInteriors/BlacksmithInterior/BlacksmithInterior.tscn");
        }
        catch
        {
            GD.PrintErr("Door just collided with something other than a Player.");
        }
        
    }
}
