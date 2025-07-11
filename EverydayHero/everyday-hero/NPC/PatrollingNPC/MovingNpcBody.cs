using Godot;
using System;

public partial class MovingNpcBody : CharacterBody2D
{
    [Export]
    public float MovementSpeed { get; set; } = 200.0f;

    private NavigationAgent2D navAgent;
    private Vector2 movementTarget;

    public override void _Ready()
    {
        navAgent = (NavigationAgent2D)GetNode("./NpcNavigationAgent");

        navAgent.PathDesiredDistance = 4.0f;
        navAgent.TargetDesiredDistance = 4.0f;
    }
    public override void _Process(double delta)
    {
        if (navAgent.IsNavigationFinished()) { return; }
        Vector2 nextPathPosition = navAgent.GetNextPathPosition();
        Vector2 direction = GlobalPosition.DirectionTo(nextPathPosition);
        Velocity = direction * MovementSpeed;
        MoveAndSlide();
    }
    public void SetTargetVector(Vector2 targetPos)
    {
        movementTarget = targetPos;
        navAgent.TargetPosition = movementTarget;
    }
}
