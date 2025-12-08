using Godot;
using System;

public partial class HeroDisplayName : RichTextLabel
{
    public virtual void ChangeName(Texture2D newTexture)
    {
        string filepath = newTexture.ResourcePath;
        this.Text = "";
        AppendText("[center]");
        switch (filepath)
        {
            case "res://Sprites/NPCSprites/Knight-Updated.png":     //Knight
                AppendText("Alistrad von Leopoldo");
                break;
            case "res://Sprites/NPCSprites/Wizard-Updated.png":     //Mage
                AppendText("Lucy Fern");
                break;
            case "res://Sprites/NPCSprites/Monk-Updated.png":       //Monk
                AppendText("Rashao Kahan");
                break;
            case "res://Sprites/NPCSprites/Rogue-Updated.png":      //Rogue
                AppendText("Jack Decker");
                break;
            case "res://Sprites/NPCSprites/Healer-Updated.png":     //Cleric
                AppendText("Rosalind Deacon");
                break;
            case "res://Sprites/NPCSprites/Ranger-Updated.png":     //Ranger
                AppendText("Thornton Breyer");
                break;
            case "res://Sprites/NPCSprites/Manager-Philip.png":
                AppendText("Manager Phillip");
                break;
            default:
            break;
        }
    }
}
