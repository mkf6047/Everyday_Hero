using Godot;
using System;

public partial class ClassAndRank : Node2D
{
    RichTextLabel textbox;

    public override void _Ready()
    {
        textbox = (RichTextLabel)GetNode("Textbox");
    }

    public void LoadNextParty(int partyNum)
    {
        if (PartyLists.Instance.parties[partyNum] != null)
        {
            textbox.Text = "";
            textbox.AppendText("[font_size=22]Party Size: " + PartyLists.Instance.parties[partyNum].Count); 
            textbox.Newline();
            for (int i = 0; i < PartyLists.Instance.parties[partyNum].Count; i++)
            {
                //PartyLists.Instance.parties[partyNum][i];
                textbox.AddText("Class: " + PartyLists.Instance.parties[partyNum][i].heroClass);
                textbox.PushIndent(3);
                textbox.AddText("Rank: " + PartyLists.Instance.parties[partyNum][i].heroRank);
                textbox.Newline();
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
