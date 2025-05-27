using Godot;
using System;

public partial class CollideLeft : Area2D
{
    Sprite2D NPCsprite;

    public override void _Ready()
    {
        base._Ready();
        NPCsprite = (Sprite2D)GetNode("/root/MainScene/Interactable/RigidBody2D/InteractiveSprite");
    }


    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            if (Input.IsActionPressed("Interact"))
            {
                NPCsprite.Texture = GD.Load<Texture2D>("res://Sprites/Interacted.png");
            }
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
            GD.PrintErr("Interactive item just stopped colliding with something other than a Player.");
        }
    }
}
