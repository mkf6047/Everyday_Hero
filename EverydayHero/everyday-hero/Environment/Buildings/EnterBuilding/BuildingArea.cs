using Godot;
using System;

public partial class BuildingArea : Node2D
{
    [Export]
    string buildingScene, buildingName;
    [Export]
    int buildingWidth, buildingHeight;
    BuildingHitbox hitbox;
    BuildingName nameplate;

    bool mouseIn = false;
    public override void _Ready()
    {
        hitbox = (BuildingHitbox)GetNode("BuildingHitbox");
        hitbox.CallDeferred("UpdateShape", buildingWidth, buildingHeight);
        var holder = GetTree().GetFirstNodeInGroup("BuildingNameplate");
        if (holder is BuildingName building)
        {
            nameplate = building;
        }
        base._Ready();
    }
    public override void _Process(double delta)
    {
        if (mouseIn)
        {
            if (Input.IsMouseButtonPressed(MouseButton.Left))
            {
                PlayerStats.Instance.playerLocation = new Vector2(0, 58);
                GetTree().CallDeferred("change_scene_to_file", buildingScene);
            }
        }
    }

    public virtual void MouseEnter()
    {
        mouseIn = true;
        nameplate.UpdateText(buildingName);
    }

    public virtual void MouseExit()
    {
        mouseIn = false;
        nameplate.HideThis();
    } 
}
