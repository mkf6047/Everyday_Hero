using Godot;
using System;

public partial class BuildingHitbox : Area2D
{
    private CollisionShape2D collisionHitbox;

    public override void _Ready()
    {
        collisionHitbox = (CollisionShape2D)GetNode("BuildingHitboxShape");
        base._Ready();
    }

    public void UpdateShape(int h, int w)
    {
        RectangleShape2D rectShape = new RectangleShape2D();
        rectShape.Size = new Vector2(w, h);
        collisionHitbox.Shape = rectShape;
    }
}
