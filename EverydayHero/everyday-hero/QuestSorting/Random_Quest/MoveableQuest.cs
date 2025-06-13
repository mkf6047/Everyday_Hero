using Godot;
using System;

public partial class MoveableQuest : CharacterBody2D
{
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
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            if (chosen && (@event.IsPressed() && mouseIn))
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

    public void mouseEnter()
    {
        mouseIn = true;
    }

    public void mouseExit()
    {
        mouseIn = false;
    }

}
