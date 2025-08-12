using Godot;
using System;

public partial class StaticNpc : Node2D
{
    [Export]
    public Texture2D sprite;
    [Export]
    public string dialougeFilepath;
    [Export]
    public bool isShopNPC;
    [Export]
    public string shopFilepath;

    Sprite2D npcSprite;

    public override void _Ready()
    {
        npcSprite = (Sprite2D)GetNode("./NPCRigidBody2D/NPCSprite");
        npcSprite.Texture = sprite;
    }

}
