using Godot;
using System;
using System.Linq;

public partial class PartyLists : Node
{
	public static PartyLists Instance;

	public Godot.Collections.Array<Godot.Collections.Array<HeroStats>> parties;
	public override void _Ready()
	{
		parties = new Godot.Collections.Array<Godot.Collections.Array<HeroStats>>();
		Godot.Collections.Array<HeroStats> newParty = new Godot.Collections.Array<HeroStats>();
		MakeStaticParty();

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
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Front.png");
					break;
				case 1:
					newPartyMember.heroClass = "Mage";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Wizard-Front.png");
					break;
				case 2:
					newPartyMember.heroClass = "Monk";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Monk-Front.png");
					break;
				case 3:
					newPartyMember.heroClass = "Rogue";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Rogue-Front.png");
					break;
				case 4:
					newPartyMember.heroClass = "Cleric";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Healer-Front.png");
					break;
				case 5:
					newPartyMember.heroClass = "Ranger";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Ranger-Front.png");
					break;
				default:
					newPartyMember.heroClass = "Knight";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Front.png");
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
			newParty.Append(newPartyMember);
		}
		parties.Append(newParty);
	}
	

	public void MakeStaticParty()
	{
		Godot.Collections.Array<HeroStats> newParty = new Godot.Collections.Array<HeroStats>();
		for (int i = 0; i <= 5; i++)
		{
			HeroStats newPartyMember = new HeroStats();
			switch (i)
			{
				case 0:
					newPartyMember.heroClass = "Knight";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Front.png");
					break;
				case 1:
					newPartyMember.heroClass = "Cleric";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Healer-Front.png");
					break;
				case 2:
					newPartyMember.heroClass = "Mage";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Wizard-Front.png");
					break;
				case 3:
					newPartyMember.heroClass = "Monk";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Monk-Front.png");
					break;
				case 4:
					newPartyMember.heroClass = "Ranger";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Ranger-Front.png");
					break;
				case 5:
					newPartyMember.heroClass = "Rogue";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Rogue-Front.png");
					break;
				default:
					newPartyMember.heroClass = "Knight";
					newPartyMember.sprite.Texture = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Front.png");
					break;
			}
			newPartyMember.heroRank = "F";
			newParty.Add(newPartyMember);
		}
		parties.Add(newParty);
	}

	public void CalculateFailure(int partyMember)
    {
		for(int i = 0; i < parties[0][partyMember].currentQuestsNames.Count; i++)
        {
            string questType = parties[0][partyMember].currentQuestsTypes[i];
			string questName = parties[0][partyMember].currentQuestsNames[i];
			int questRank = 0;
			int heroRank = 0;
			using(var file = FileAccess.Open("res://QuestSorting/QuestInformation/" + questType +"/"+questName+".txt", FileAccess.ModeFlags.Read))
            {
                string value = file.GetLine(); 	//Value = Quest Name
				value = file.GetLine();			//value = quest description
				value = file.GetLine();			//value = quest rank
				questRank = RankToInt(value);
				heroRank = RankToInt(parties[0][partyMember].heroRank);
            }
			if(heroRank == questRank)
            {
                parties[0][partyMember].goodbadprogress[i] = 90;
            }
			else if (heroRank < questRank)
            {
                int difference = questRank - heroRank;
				double holder = 90;
				for(int j = 0; j < difference; j++){ holder *= 0.75; }
				parties[0][partyMember].goodbadprogress[i] = (int)Math.Round(holder);
            }
            else
            {
                parties[0][partyMember].goodbadprogress[i] = 100;
            }
        }
    }

	int RankToInt(string rank)
    {
		int returnVal = 0;
		switch (rank)
		{
			case "SSS":
				returnVal = 9;
				break;
			case "SS":
				returnVal = 8;
				break;
			case "S":
				returnVal = 7;
				break;
			case "A":
				returnVal = 6;
				break;
			case "B":
				returnVal = 5;
				break;
			case "C":
				returnVal = 4;
				break;
			case "D":
				returnVal = 3;
				break;
			case "E":
				returnVal = 2;
				break;
			case "F":
				returnVal = 1;
				break;
			default:
				returnVal = 0;
				break;
		}
        return returnVal;
    }
}
