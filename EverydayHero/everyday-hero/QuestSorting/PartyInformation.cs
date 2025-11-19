using Godot;
using System;

public partial class PartyInformation : Node2D
{
	int currentHero = 1;
	LeaderSprite currentHeroSprite;
	public override void _Ready()
	{
		currentHeroSprite = (LeaderSprite)GetNode("LeaderSprite");
		while (PartyLists.Instance.parties[0][currentHero - 1].onQuest == true) { currentHero++; }
		ChangeActiveHero(currentHero);
	}

	public void ChangeActiveHero(int change)
    {
		currentHero = change;
		switch (change)
			{
				case 1:
					currentHeroSprite.ReplaceSprite("Knight");
					break;
				case 2:
					currentHeroSprite.ReplaceSprite("Cleric");
					break;
				case 3:
					currentHeroSprite.ReplaceSprite("Mage");
					break;
				case 4:
					currentHeroSprite.ReplaceSprite("Monk");
					break;
				case 5:
					currentHeroSprite.ReplaceSprite("Ranger");
					break;
				case 6:
					currentHeroSprite.ReplaceSprite("Rogue");
					break;
				default:
					currentHeroSprite.ReplaceSprite("Knight");
					break;
			}
    }

}
