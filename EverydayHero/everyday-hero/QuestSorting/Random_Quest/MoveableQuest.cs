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
        if (@event.IsActionPressed("mouse_click"))
        {
            if (chosen && mouseIn)
            {
                draggingDistance = Position.DistanceTo(GetViewport().GetMousePosition());
                dir = (GetViewport().GetMousePosition() - Position).Normalized();
                dragging = true;
                newPosition = GetViewport().GetMousePosition() - draggingDistance * dir;
                GD.Print("dragging");
            }
            else
            {
                dragging = false;
                chosen = false;
                GD.Print("not dragging");
                GD.Print(mouseIn + " - " + @event.IsPressed());
            }
        }
        else if (@event is InputEventMouseMotion)
        {
            if (dragging)
            {
                newPosition = GetViewport().GetMousePosition() - draggingDistance * dir;
                GD.Print("dragging");
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

    public void MouseEnter()
    {
        mouseIn = true;
        GD.Print("mousein = true");
    }

    public void MouseExit()
    {
        mouseIn = false;
        GD.Print("mousein = false");
    }

}
