using Godot;
using System;

public partial class CollideLeft : Area2D
{
    Sprite2D NPCsprite;

    bool isColliding;

    public override void _Ready()
    {
        base._Ready();
        NPCsprite = (Sprite2D)GetNode("/root/MainScene/Interactable/RigidBody2D/InteractiveSprite");
        isColliding = false;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (isColliding) {
            if (Input.IsActionPressed("Interact"))
            {
                NPCsprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Interacted.png");
            }
        }
    }



    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            isColliding = true;
            Sprite2D notice = (Sprite2D)GetNode("../../Player/PlayerBody2D/Notice");
            notice.Call("ShowNotice");
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
            isColliding = false;
            Sprite2D notice = (Sprite2D)GetNode("../../Player/PlayerBody2D/Notice");
            notice.Call("HideNotice");
        }
        catch
        {
            GD.PrintErr("Interactive item just stopped colliding with something other than a Player.");
        }
    }
}
