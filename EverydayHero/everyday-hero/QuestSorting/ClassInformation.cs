using Godot;
using System;

public partial class ClassInformation : Node2D
{
	RichTextLabel textbox;
	public override void _Ready(){
		textbox = (RichTextLabel)GetNode("ClassInfoTextbox");
		this.Hide();
	}
	
	
	public void UpdateCharInfo(string questerClass)
	{
		textbox.Text = "";
		textbox.AppendText("[font_size=14]");
		switch(questerClass){
			case "Knight":
				textbox.AppendText("- Able to utilize heavy equipment, with the strength to carry it.");
				textbox.AppendText("- Slow. Party takes longer to complete quests.");
				textbox.AppendText("- Brings back more spoils on quest completion.");
				break;
			case "Mage":
				textbox.AppendText("- Utilizes a wide range of spells, able to solve problems with magic.");
				textbox.AppendText("- Due to mana usage, party takes longer to recover after a quest.");
				textbox.AppendText("- Able to identify & discover magical spoils.");
				break;
			case "Monk":
				textbox.AppendText("- Able to reach out of the way areas in a short amount of time.");
				textbox.AppendText("- Due to energy expended, the party takes longer to recover after a quest.");
				textbox.AppendText("- Lowers the chance of complications occuring during quests.");
				break;
			case "Rouge":
				textbox.AppendText("- Able to disarm traps and complex mechanisms");
				textbox.AppendText("- Lighter armour leads to heavier injuries, party takes longer to recover after a quest");
				textbox.AppendText("- Able to identify and discover monetary spoils.");
				break;
			case "Cleric":
				textbox.AppendText("- Able to dispel curses, and fortifies the party with healing spells.");
				textbox.AppendText("- Unable to equip armour without holy sigil.");
				textbox.AppendText("- Reduces time spent by party recovering after quest.");
				break;
			case "Ranger":
				textbox.AppendText("- Able to scout areas, reducing travel times & chance of complications during quest.");
				textbox.AppendText("- Rquires arrows to fight, lowering the reward.");
				textbox.AppendText("- Able to discover and identify medicinal spoils.");
				break;
			default:
				textbox.AppendText("Unable to Identify Class.");
				break;
		}
	}
}
