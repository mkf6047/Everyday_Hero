using Godot;
using System;

public partial class PartyLists : Node
{
	public static PartyLists Instance;

	public Godot.Collections.Array<Godot.Collections.Array<HeroStats>> parties;
	public override void _Ready()
	{
		parties = new Godot.Collections.Array<Godot.Collections.Array<HeroStats>>();
		Instance = this;    //last line of function
	}

	public void MakeParty(int partySize)
	{
		Godot.Collections.Array<HeroStats> newParty = new Godot.Collections.Array<HeroStats>();
		for (int i = 0; i < partySize; i++)
		{
			HeroStats newPartyMember = new HeroStats();
			int rand = GD.RandRange(0, 5);
			switch (rand)
			{
				case 0:
					newPartyMember.heroClass = "Knight";
					break;
				case 1:
					newPartyMember.heroClass = "Mage";
					break;
				case 2:
					newPartyMember.heroClass = "Monk";
					break;
				case 3:
					newPartyMember.heroClass = "Rogue";
					break;
				case 4:
					newPartyMember.heroClass = "Cleric";
					break;
				case 5:
					newPartyMember.heroClass = "Ranger";
					break;
				default:
					newPartyMember.heroClass = "Knight";
					break;
			}
			rand = GD.RandRange(0, 99);
			if (rand >= 98) { newPartyMember.heroRank = "S"; }
			else if (rand >= 90) { newPartyMember.heroRank = "A"; }
			else if (rand >= 85) { newPartyMember.heroRank = "B"; }
			else if (rand >= 75) { newPartyMember.heroRank = "C"; }
			else if (rand >= 60) { newPartyMember.heroRank = "D"; }
			else if (rand >= 45) { newPartyMember.heroRank = "E"; }
			else { newPartyMember.heroRank = "F"; }
			newParty.Add(newPartyMember);
		}
		parties.Add(newParty);
	}
}
