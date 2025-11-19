using Godot;
using System;

public partial class ProgressCharacterInfo : Area2D
{
	[Export]
	public int charOrder = 0;
	public int partySize = 6;
	ClassInformationProgress classInfo;
	PartyInformation partyInfo;
	ClassAndRank parent;
	bool mouseIn = false;
	public override void _Ready()
	{
		classInfo = (ClassInformationProgress)GetNode("ClassInformation2");
		partyInfo = (PartyInformation)GetNode("../../");
		parent = (ClassAndRank)GetParent();
	}

    public override void _Process(double delta)
    {
        if (Input.IsMouseButtonPressed(MouseButton.Left) && mouseIn && !PartyLists.Instance.parties[0][charOrder -1].onQuest)
        {
			partyInfo.ChangeActiveHero(charOrder);
			parent.Hide();
        }
    }

	public void updateInfo(string questerClass)
	{
		classInfo.UpdateCharInfo(questerClass);
	}
	public void MouseEnter()
	{
		classInfo.Show();
		mouseIn = true;
	}
	public void MouseExit()
	{
		classInfo.Hide();
		mouseIn = false;
		//GD.Print("exit");
	}
}
