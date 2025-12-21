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
	HeroList heroList;
	HeroAbilitiesRank describer;
	bool mouseIn = false;
	public override void _Ready()
    {
        scene = (QuestSortingScene)GetNode("../../../");
        activeHero = (LeaderSprite)GetNode("../../LeaderSprite");
		describer = (HeroAbilitiesRank)GetNode("HeroAbilitiesRank");
		heroList = (HeroList)GetNode("../Textbox");
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
		heroList.UpdateHeroPresence(charOrder - 1);
		describer.Show();
		//GD.Print("Enter " + charOrder);
	}
	public void MouseExit()
	{
		mouseIn = false;
		heroList.UpdateHeroPresence();
		describer.Hide();
		//GD.Print("Exit " + charOrder);
	}
}
