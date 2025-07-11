using Godot;
using System;

public partial class MovingNpc : Node2D
{
    [Export]
    public Godot.Collections.Array<Vector2> Targets { get; set; } = new Godot.Collections.Array<Vector2> { };

    private MovingNpcBody body;
    private int count = 0;

    public override void _Ready()
    {
        body = (MovingNpcBody)GetNode("./MovingNPCBody");
    }
    public override void _Process(double delta)
    {
        if (!body.NavigationStatus()) { return; }
        count++;
        if (count >= Targets.Count) { count = 0; }
        SetNewTarget(Targets[count]);
    }


    public void SetNewTarget(Vector2 newTarget)
    {
        body.SetTargetVector(newTarget);
    }
}
