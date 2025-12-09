using Godot;
using System;

public partial class ClassInformationV2 : Node2D
{
	RichTextLabel textbox;
	//CharacterInfo charInfo;
	public override void _Ready(){
		textbox = (RichTextLabel)GetNode("ClassInfoTextbox");
		//charInfo = (CharacterInfo)GetParent();
		//UpdateCharInfo(PartyLists.Instance.parties[0][charInfo.charOrder - 1].heroClass);
		this.Hide();
	}
	
	
	public void UpdateCharInfo(string questerClass)
	{
		textbox.Text = "";
		textbox.AppendText("[font_size=14]");
		switch(questerClass){
			case "Knight":
				textbox.AppendText("- Able to utilize heavy equipment, with the strength to carry it."); textbox.Newline();
				textbox.AppendText("- Slow. Party takes longer to complete quests."); textbox.Newline();
				textbox.AppendText("- Brings back more spoils on quest completion."); textbox.Newline();
				break;
			case "Mage":
				textbox.AppendText("- Utilizes a wide range of spells, able to solve problems with magic."); textbox.Newline();
				textbox.AppendText("- Due to mana usage, party takes longer to recover after a quest."); textbox.Newline();
				textbox.AppendText("- Able to identify & discover magical spoils."); textbox.Newline();
				break;
			case "Monk":
				textbox.AppendText("- Able to reach out of the way areas in a short amount of time."); textbox.Newline();
				textbox.AppendText("- Due to energy expended, the party takes longer to recover after a quest."); textbox.Newline();
				textbox.AppendText("- Lowers the chance of complications occuring during quests."); textbox.Newline();
				break;
			case "Rogue":
				textbox.AppendText("- Able to disarm traps and complex mechanisms"); textbox.Newline();
				textbox.AppendText("- Lighter armour leads to heavier injuries, party takes longer to recover after a quest"); textbox.Newline();
				textbox.AppendText("- Able to identify and discover monetary spoils."); textbox.Newline();
				break;
			case "Cleric":
				textbox.AppendText("- Able to dispel curses, and fortifies the party with healing spells."); textbox.Newline();
				textbox.AppendText("- Unable to equip armour without holy sigil."); textbox.Newline();
				textbox.AppendText("- Reduces time spent by party recovering after quest."); textbox.Newline();
				break;
			case "Ranger":
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
