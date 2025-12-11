using Godot;
using System;

public partial class ClassAndRank : Control
{
	RichTextLabel textbox, rankDisplay, isOnQuest;
	LeaderSprite leaderSprite;

	public override void _Ready()
	{
		textbox = (RichTextLabel)GetNode("Textbox");
		rankDisplay = (RichTextLabel)GetNode("RankDisplay");
		isOnQuest = (RichTextLabel)GetNode("In-Out");
		leaderSprite = (LeaderSprite)GetNode("../LeaderSprite");

		rankDisplay.Text = "";
		isOnQuest.Text = "";
		rankDisplay.AppendText("[font_size=20][b]Adventurer Rank:[/b]");
		isOnQuest.AppendText("[font_size=20][b]Status:[/b]");

		string pre ="", post = "";

		for(int i = 0; i < 6; i++)
        {
			rankDisplay.Newline();
			isOnQuest.Newline();
			if (PartyLists.Instance.parties[0][i].onQuest) {
				pre = "[color=black]";
				post = "[/color]";
				isOnQuest.AppendText(pre + "Out On Quest For " + PartyLists.Instance.parties[0][i].daysRemainingOnQuest + " More Day(s)" + post); 
			}
			else{
				pre = "";
				post = "";
				isOnQuest.AppendText(pre + "Present" + post); 
			}
			rankDisplay.AppendText(pre + "Rank: " + PartyLists.Instance.parties[0][i].heroRank + post);
        }

		this.Hide();
	}

	public void UpdateQuesterStatus()
    {
		isOnQuest.Text = "";
		isOnQuest.AppendText("[font_size=20][b]Status:[/b]");
        for(int i = 0; i < 6; i++)
        {
			isOnQuest.Newline();
			if (PartyLists.Instance.parties[0][i].onQuest) { isOnQuest.AppendText("Out On Quest"); }
			else{ isOnQuest.AppendText("[color=black]Present[/color]"); }
        }
    }

	// public void LoadNextParty(int partyNum)
	// {
	// 	if (PartyLists.Instance.parties.Count > partyNum)
	// 	{
	// 		textbox.Text = "";
	// 		rankDisplay.Text = "";
	// 		textbox.AppendText("[font_size=22]Party Size: " + PartyLists.Instance.parties[partyNum].Count);
	// 		rankDisplay.AppendText("[font_size=22]");
	// 		textbox.Newline();
	// 		rankDisplay.Newline();
	// 		for (int i = 0; i < PartyLists.Instance.parties[partyNum].Count; i++)
	// 		{
	// 			//PartyLists.Instance.parties[partyNum][i];
	// 			if (i == 0) { leaderSprite.ReplaceSprite(PartyLists.Instance.parties[partyNum][i].heroClass); }
	// 			textbox.AddText("Class: " + PartyLists.Instance.parties[partyNum][i].heroClass);
	// 			rankDisplay.AddText("Rank: " + PartyLists.Instance.parties[partyNum][i].heroRank);
	// 			textbox.Newline();
	// 			rankDisplay.Newline();
	// 		}
	// 	}
	// 	else
	// 	{
	// 		while (PartyLists.Instance.parties.Count <= partyNum)
	// 		{
	// 			int newPartySize = GD.RandRange(3, 5);
	// 			PartyLists.Instance.MakeParty(newPartySize);
	// 		}
	// 		LoadNextParty(partyNum);
	// 	}
	// }
}
