using Godot;
using System;

public partial class BuildingArea : Node2D
{
    [Export]
    string buildingScene;
    [Export]
    int buildingWidth, buildingHeight;
    BuildingHitbox hitbox;

    bool mouseIn = false;
    public override void _Ready()
    {
        hitbox = (BuildingHitbox)GetNode("BuildingHitbox");
        hitbox.CallDeferred("UpdateShape", buildingWidth, buildingHeight);
        base._Ready();
    }
    public override void _Process(double delta)
    {
        if (mouseIn)
        {
            if (Input.IsMouseButtonPressed(MouseButton.Left))
            {
                GetTree().CallDeferred("change_scene_to_file", buildingScene);
            }
        }
    }

    public virtual void MouseEnter()
    {
        mouseIn = true;
    } 

    public virtual void MouseExit()
    {
        mouseIn = false;
    } 
}
