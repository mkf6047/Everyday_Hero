using Godot;
using System;

public partial class RevealPartyInfo : Area2D
{
    bool mouseIn = false;
    ClassAndRank classAndRank;
    public override void _Ready()
    {
        classAndRank = (ClassAndRank)GetNode("../../../Class&Rank");
    }
    public override void _Process(double delta)
    {
        if (mouseIn)
        {
            if (Input.IsMouseButtonPressed(MouseButton.Left))
            {
                classAndRank.Show();
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
