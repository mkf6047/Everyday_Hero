using Godot;
using System;

public partial class RevealPartyInfo : Area2D
{
    bool mouseIn = false;
    ClassAndRank classAndRank;
    Sprite2D above;
    Texture2D mouseOut, mouseInside;
    public override void _Ready()
    {
        classAndRank = (ClassAndRank)GetNode("../../../Class&Rank");
        mouseOut = GD.Load<Texture2D>("res://Sprites/OverlaySprites/TextboxEnd.png");
        mouseInside = GD.Load<Texture2D>("res://Sprites/OverlaySprites/BoxSelected.png");
        above = (Sprite2D)GetParent();
    }
    public override void _Process(double delta)
    {
        if (mouseIn)
        {
            if (Input.IsActionJustPressed("mouse_click"))
            {
                classAndRank.Show();
            }
        }
    }
    public virtual void MouseEnter()
    {
        mouseIn = true;
        above.Texture = mouseInside;
    }
    public virtual void MouseExit()
    {
        mouseIn = false;
        above.Texture = mouseOut;
    } 
}
