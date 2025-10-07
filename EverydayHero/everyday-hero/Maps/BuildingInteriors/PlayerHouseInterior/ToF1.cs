using Godot;
using System;

public partial class ToF1 : Area2D
{
    public virtual void OnArea2DBodyEntered(Node2D body)    //when an item collides with this object
    {
        try         //if the item is a player, transition to exterior
        {
            Player player = (Player)body;           //checks colliding item is a player
            PlayerStats.Instance.isInside = false;  //change bool signifying interior or exterior
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/BuildingInteriors/PlayerHouseInterior/PlayerHouseInterior.tscn");   //load new map
        }
        catch   //if not a player, output error & what collided.
        {
            GD.PrintErr("Door just collided with something other than a Player.");
            GD.PrintErr(body);
        }
        
    }
}
