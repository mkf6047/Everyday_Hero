using Godot;
using System;

public partial class ClassAndRank : Node2D
{
    RichTextLabel textbox, rankDisplay;

    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("Textbox");
        rankDisplay = (RichTextLabel)GetNode("RankDisplay");
    }

    public void LoadNextParty(int partyNum)
    {
        if (PartyLists.Instance.parties[partyNum] != null)
        {
            textbox.Text = "";
            rankDisplay.Text = "";
            textbox.AppendText("[font_size=22]Party Size: " + PartyLists.Instance.parties[partyNum].Count); 
            rankDisplay.AppendText("[font_size=22]"); 
            textbox.Newline();
            rankDisplay.Newline();
            for (int i = 0; i < PartyLists.Instance.parties[partyNum].Count; i++)
            {
                //PartyLists.Instance.parties[partyNum][i];
                textbox.AddText("Class: " + PartyLists.Instance.parties[partyNum][i].heroClass);
                rankDisplay.AddText("Rank: " + PartyLists.Instance.parties[partyNum][i].heroRank);
                textbox.Newline();
                rankDisplay.Newline();
            }
        }
        else
        {
            while (PartyLists.Instance.parties[partyNum] == null)
            {
                int newPartySize = GD.RandRange(3, 5);
                PartyLists.Instance.MakeParty(newPartySize);
            }
            LoadNextParty(partyNum);
        }
    }
}
