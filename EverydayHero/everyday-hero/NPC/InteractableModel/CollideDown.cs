using Godot;
using System;

public partial class CollideDown : Area2D
{


    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
        }
        catch
        {
            GD.PrintErr("Interactive item just collided with something other than a Player.");
        }
    }

    public virtual void OnArea2DBodyExited(Node2D body)
    {
        try
        {
            Player player = (Player)body;
        }
        catch
        {
            GD.PrintErr("Interactive item just collided with something other than a Player.");
        }
    }
}
