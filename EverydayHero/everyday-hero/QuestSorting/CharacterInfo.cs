using Godot;
using System;

public partial class CharacterInfo : Area2D
{
	[Export]
	public int charOrder = 0;
	public int partySize = 6;
	ClassInformation classInfo;
	QuestSortingScene scene;
	bool mouseIn = false;
	public override void _Ready()
	{
		classInfo = (ClassInformation)GetNode("ClassInformation2");
		scene = (QuestSortingScene)GetNode("../../../");
	}

    public override void _Process(double delta)
    {
        if (Input.IsMouseButtonPressed(MouseButton.Left) && mouseIn && !PartyLists.Instance.parties[0][charOrder -1].onQuest)
        {
			scene.ChangeActiveHero(charOrder);
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
