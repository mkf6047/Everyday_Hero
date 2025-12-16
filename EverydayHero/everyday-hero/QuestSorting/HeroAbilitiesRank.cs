using Godot;
using System;

public partial class HeroAbilitiesRank : Node2D
{
    SelectHero parent;
    RichTextLabel textbox;
    public override void _Ready()
    {
        parent = (SelectHero)GetParent();
        textbox = (RichTextLabel)GetNode("ClassInfoTextbox");
        UpdateCharInfo(parent.charOrder);
        this.Hide();
    }


	public void UpdateCharInfo(int questerNum)
	{
		textbox.Text = "";
		textbox.AppendText("[font_size=14]");
		switch(questerNum){
			case 1:
				textbox.AppendText("- Rank: " + PartyLists.Instance.parties[0][0].heroRank); textbox.Newline();
				textbox.AppendText("- Able to utilize heavy equipment, with the strength to carry it."); textbox.Newline();
				textbox.AppendText("- Slow. Party takes longer to complete quests."); textbox.Newline();
				textbox.AppendText("- Brings back more spoils on quest completion."); textbox.Newline();
				break;
			case 3:
				textbox.AppendText("- Rank: " + PartyLists.Instance.parties[0][2].heroRank); textbox.Newline();
				textbox.AppendText("- Utilizes a wide range of spells, able to solve problems with magic."); textbox.Newline();
				textbox.AppendText("- Due to mana usage, party takes longer to recover after a quest."); textbox.Newline();
				textbox.AppendText("- Able to identify & discover magical spoils."); textbox.Newline();
				break;
			case 4:
				textbox.AppendText("- Rank: " + PartyLists.Instance.parties[0][3].heroRank); textbox.Newline();
				textbox.AppendText("- Able to reach out of the way areas in a short amount of time."); textbox.Newline();
				textbox.AppendText("- Due to energy expended, the party takes longer to recover after a quest."); textbox.Newline();
				textbox.AppendText("- Lowers the chance of complications occuring during quests."); textbox.Newline();
				break;
			case 6:
				textbox.AppendText("- Rank: " + PartyLists.Instance.parties[0][5].heroRank); textbox.Newline();
				textbox.AppendText("- Able to disarm traps and complex mechanisms"); textbox.Newline();
				textbox.AppendText("- Lighter armour leads to heavier injuries, party takes longer to recover after a quest"); textbox.Newline();
				textbox.AppendText("- Able to identify and discover monetary spoils."); textbox.Newline();
				break;
			case 2:
				textbox.AppendText("- Rank: " + PartyLists.Instance.parties[0][1].heroRank); textbox.Newline();
				textbox.AppendText("- Able to dispel curses, and fortifies the party with healing spells."); textbox.Newline();
				textbox.AppendText("- Unable to equip armour without holy sigil."); textbox.Newline();
				textbox.AppendText("- Reduces time spent by party recovering after quest."); textbox.Newline();
				break;
			case 5:
				textbox.AppendText("- Rank: " + PartyLists.Instance.parties[0][4].heroRank); textbox.Newline();
				textbox.AppendText("- Able to scout areas, reducing travel times & chance of complications during quest."); textbox.Newline();
				textbox.AppendText("- Rquires arrows to fight, lowering the reward."); textbox.Newline();
				textbox.AppendText("- Able to discover and identify medicinal spoils."); textbox.Newline();
				break;
			default:
				textbox.AppendText("Unable to Identify Class.");
				break;
		}
	}
}
