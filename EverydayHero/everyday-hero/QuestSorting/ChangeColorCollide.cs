using Godot;
using System;

public partial class ChangeColorCollide : Area2D
{
    LeaderSprite parent;
    ClassInformationV2 classInfo;
    public override void _Ready()
    {
        parent = (LeaderSprite)GetParent();
        classInfo = (ClassInformationV2)GetNode("ClassInformation2");
    }

    public virtual void OnArea2DBodyEntered(Node2D body)
    {
		try
		{
			MoveableQuest quest = (MoveableQuest)body;
			parent.Collision();
		}
		catch
		{
			GD.PrintErr("Deposite area just collided with something other than a Quest.");
		}
        
    }

    public virtual void OnArea2DBodyExited(Node2D body)
    {
		try
		{
			MoveableQuest quest = (MoveableQuest)body;
			parent.NoCollision();
		}
		catch
		{
			GD.PrintErr("Deposite area just collided with something other than a Quest.");
		}
    }

    public void UpdateClassInfo(string questerClass)
    {
        classInfo.UpdateCharInfo(questerClass);
    }

	public void MouseEnter()
	{
		classInfo.Show();
	}
	public void MouseExit()
	{
		classInfo.Hide();
	}
}
