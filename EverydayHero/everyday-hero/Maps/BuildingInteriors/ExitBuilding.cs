using Godot;
using System;

public partial class ExitBuilding : Area2D
{
    //Code for exiting buildings
    public virtual void OnArea2DBodyEntered(Node2D body)    //when an item collides with this object
    {
        try         //if the item is a player, transition to exterior
        {
            Player player = (Player)body;           //checks colliding item is a player
            PlayerStats.Instance.isInside = false;  //change bool signifying interior or exterior
            PlayerStats.Instance.playerLocationExterior.Y += 20;    //move player last known location away from enterance to building
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/ExteriorMaps/MainScene.tscn");   //load new map
        }
        catch   //if not a player, output error & what collided.
        {
            GD.PrintErr("Door just collided with something other than a Player.");
            GD.PrintErr(body);
        }
        
    }
}
