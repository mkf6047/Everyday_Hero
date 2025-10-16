using Godot;
using System;

public partial class CharacterInfo : Area2D
{
	[Export]
	int charOrder = 0;
	public int partySize = 6;
	ClassInformation classInfo;
	public override void _Ready()
	{
		classInfo = (ClassInformation)GetNode("ClassInformation2");
	}
	public void updateInfo(string questerClass)
	{
		classInfo.UpdateCharInfo(questerClass);
	}
	public void MouseEnter()
	{
		if (charOrder <= partySize)
		{
			GD.Print("enter");
			classInfo.Show();
		}
	}
	public void MouseExit()
	{
		classInfo.Hide();
		GD.Print("exit");
	}
}
