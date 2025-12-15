using Godot;
using System;

public partial class HeroList : RichTextLabel
{
    public void UpdateHeroPresence()
    {
        string pre, post, name;
        for(int i = 0; i < 6; i++)
        {
            switch (i)
            {
                case 0:
                name = "Allistrad von Leopoldo";
                break;
                case 1:
                name = "Rosalind Deacon";
                break;
                case 2:
                name = "Lucy Fern";
                break;
                case 3:
                name = "Rashao Kahan";
                break;
                case 4:
                name = "Thornton Breyer";
                break;
                case 5:
                name = "Jack Decker";
                break;
                default:
                name = "Phillip";
                break;
            }
			if (PartyLists.Instance.parties[0][i].onQuest) {
				pre = "[color=black]";
				post = "[/color]";
			}
			else{
				pre = "";
				post = "";
			}
		    AppendText(pre + name + post);
        }
    }
}
