using Godot;
using System;

public partial class SelectHero : Area2D
{
    [Export]
	public int charOrder = 0;
	public int partySize = 6;
	ClassInformation classInfo;
	QuestSortingScene scene;
	//ClassAndRank parent;
    LeaderSprite activeHero;

	HeroAbilitiesRank describer;
	bool mouseIn = false;
	public override void _Ready()
    {
        scene = (QuestSortingScene)GetNode("../../../");
        activeHero = (LeaderSprite)GetNode("../../LeaderSprite");
		describer = (HeroAbilitiesRank)GetNode("HeroAbilitiesRank");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("mouse_click") && mouseIn && !PartyLists.Instance.parties[0][charOrder -1].onQuest)
        {
			scene.ChangeActiveHero(charOrder);
			//activeHero.RevealActiveHero();
        }
    }

	public void updateInfo(string questerClass)
	{
		classInfo.UpdateCharInfo(questerClass);
	}
	public void MouseEnter()
	{
		mouseIn = true;
		describer.Show();
		//GD.Print("Enter " + charOrder);
	}
	public void MouseExit()
	{
		mouseIn = false;
		describer.Hide();
		//GD.Print("Exit " + charOrder);
	}
}
