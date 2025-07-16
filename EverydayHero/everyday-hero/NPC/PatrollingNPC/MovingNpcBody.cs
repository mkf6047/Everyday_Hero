using Godot;
using System;

public partial class MovingNpcBody : CharacterBody2D
{
    [Export]
    public float MovementSpeed { get; set; } = 200.0f;

    private float pathLength = 100.0f;
    private NavigationAgent2D navAgent;
    private Vector2 movementTarget;
    private Godot.Collections.Array<Vector2> pathfindingTargets = new Godot.Collections.Array<Vector2> { new Vector2(0, 0), new Vector2(80, 80) };
    int count = 0;
    double timer = 0;

    public override void _Ready()
    {
        navAgent = (NavigationAgent2D)GetNode("./NpcNavigationAgent");

        navAgent.PathDesiredDistance = 4.0f;
        navAgent.TargetDesiredDistance = 4.0f;
    }
    public override void _PhysicsProcess(double delta)
    {
        if (navAgent.IsNavigationFinished() /*&& (timer > 3.0)*/)
        {
            // count++;
            // if (count >= pathfindingTargets.Count) { count = 0; }
            // movementTarget = pathfindingTargets[count];
            // navAgent.TargetPosition = movementTarget;
            //GD.Print(navAgent.TargetPosition);
            //timer = 0.0;
            return;
        }
        //timer += delta;
        Vector2 nextPathPosition = navAgent.GetNextPathPosition();
        Vector2 direction = GlobalPosition.DirectionTo(nextPathPosition);
        Velocity = direction * MovementSpeed;
        MoveAndSlide();
    }
    public void SetTargetVector(Vector2 targetPos)
    {
        movementTarget = targetPos;
        navAgent.TargetPosition = movementTarget;
        navAgent.GetNextPathPosition();
    }
    public void SetTargets(Godot.Collections.Array<Vector2> targets)
    {
        pathfindingTargets = targets; 
    }
    public bool NavigationStatus() { return navAgent.IsNavigationFinished(); }
}
