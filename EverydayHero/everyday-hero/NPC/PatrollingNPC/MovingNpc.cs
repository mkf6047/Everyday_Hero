using Godot;
using Godot.NativeInterop;
using System;

public partial class MovingNpc : Node2D
{
    [Export]
    public Godot.Collections.Array<Vector2> Targets { get; set; } = new Godot.Collections.Array<Vector2> { };
    [Export]
    public Vector2[] Bounds { get; set; } = new Vector2[] { new Vector2(-32, -32), new Vector2(32, -32), new Vector2(32, 32), new Vector2(-32, 32) };
    [Export]
    public Texture2D NPCTexture { get; set; }

    private NavigationRegion2D navRegion;
    private NavigationPolygon navPolygon;
    private MovingNpcBody body;
    private Sprite2D NPCSprite;
    private int count = 0;
    private double timer = 0.0;

    public override void _Ready()
    {
        body = (MovingNpcBody)GetNode("./MovingNPCBody");
        NPCSprite = (Sprite2D)GetNode("./MovingNPCBody/InteractiveSprite");
        NPCSprite.Texture = NPCTexture;
        navRegion = (NavigationRegion2D)GetNode("./NPCMoveRange");
        navPolygon = navRegion.NavigationPolygon;
        navPolygon.ClearOutlines();
        navPolygon.AddOutline(Bounds);
        NavigationServer2D.BakeFromSourceGeometryData(navPolygon, new NavigationMeshSourceGeometryData2D());
        SetNewTargets();
    }
    public override void _Process(double delta)
    {
        // timer += delta;
        // if (!body.NavigationStatus()) { GD.Print("still navigating"); return; }
        // if (count >= Targets.Count) { count = 0; }
        // GD.Print(count + " " + Targets.Count);
        // if (timer >= 1.0)
        // {
        //     SetNewTarget(Targets[count]);
        //     count++;
        //     timer = 0.0;
        // }
    }


    public void SetNewTarget(Vector2 newTarget)
    {
        body.SetTargetVector(newTarget);
        GD.Print(newTarget);
    }
    public void SetNewTargets()
    {
        body.SetTargets(Targets);
    }
}
