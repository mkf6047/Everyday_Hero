using Godot;
using System;

public partial class NPCCollide : Area2D
{
    bool isColliding;
    bool isShopNPC;
    StaticNpc thisNPC;

    public override void _Ready()
    {
        thisNPC = (StaticNpc)GetParent();
        Node node = GetTree().GetFirstNodeInGroup("Player");
        isColliding = false;
        isShopNPC = thisNPC.isShopNPC;
        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (isColliding) {
            if (Input.IsActionJustPressed("Interact"))
            {
                Node node = GetTree().GetFirstNodeInGroup("Player");
                if (node is PlayerFunctions playerNode)
                {
                    if (!playerNode.IsBusy)
                    {
                        playerNode.LoadText(thisNPC.dialougeFilepath, isShopNPC, thisNPC.shopFilepath);
                    }
                }
            }
        }
    }



    public virtual void OnArea2DBodyEntered(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            isColliding = true;
            Sprite2D notice = (Sprite2D)GetNode("../../Player/PlayerBody2D/Notice");
            notice.Call("ShowNotice");
        }
        catch
        {
            GD.PrintErr("Interactive item just collided with something other than a Player.");
        }
    }

    public virtual void OnArea2DBodyExited(Node2D body)
    {
        try
        {
            Player player = (Player)body;
            isColliding = false;
            Sprite2D notice = (Sprite2D)GetNode("../../Player/PlayerBody2D/Notice");
            notice.Call("HideNotice");
        }
        catch
        {
            GD.PrintErr("Interactive item just stopped colliding with something other than a Player.");
        }
    }
}
