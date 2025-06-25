using Godot;
using System;

public partial class MoveableQuest : CharacterBody2D
{
    Sprite2D sprite;
    Vector2 newPosition;
    Vector2 dir;
    float draggingDistance;
    bool dragging;
    bool mouseIn = false;
    public bool chosen = false;
    public bool Dragging
    {
        get { return dragging; }
    }
    public override void _Ready()
    {
        sprite = (Sprite2D)GetNode("/QuestSprite");
    }
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("mouse_click"))
        {
            if (chosen && mouseIn)
            {
                draggingDistance = Position.DistanceTo(GetViewport().GetMousePosition());
                dir = (GetViewport().GetMousePosition() - Position).Normalized();
                dragging = true;
                newPosition = GetViewport().GetMousePosition() - draggingDistance * dir;
            }
            else
            {
                dragging = false;
                chosen = false;
            }
        }
        else if (@event.IsActionReleased("mouse_click"))
        {
            dragging = false;
        }
        else if (@event is InputEventMouseMotion)
        {
            if (dragging)
            {
                newPosition = GetViewport().GetMousePosition() - draggingDistance * dir;
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (dragging)
        {
            Velocity = (newPosition - Position) * new Vector2(30, 30);
            MoveAndSlide();
        }
    }

    public void isChosen()
    {
        chosen = true;
    }

    public void notChosen()
    {
        chosen = false;
    }

    public virtual void MouseEnter()
    {
        mouseIn = true;
        sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestSelected.png");
    }

    public virtual void MouseExit()
    {
        mouseIn = false;
        sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestPaper.png");
    }
}
