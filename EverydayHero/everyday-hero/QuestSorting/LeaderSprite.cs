using Godot;
using System;

public partial class LeaderSprite : Sprite2D
{
    Texture2D kniTex, magTex, monTex, rogTex, cleTex, ranTex, philTex;

    public override void _Ready()
    {
        kniTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Front.png");
        magTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Wizard-Front.png");
        monTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Monk-Front.png");
        rogTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Rogue-Front.png");
        cleTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Healer-Front.png");
        ranTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Ranger-Front.png");
        philTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Philip-Sprite.png");
    }


    public void ReplaceSprite(string charClass)
    {
        switch (charClass)
        {
            case "Knight":
                this.Texture = kniTex;
                break;
            case "Mage":
                this.Texture = magTex;
                break;
            case "Monk":
                this.Texture = monTex;
                break;
            case "Rogue":
                this.Texture = rogTex;
                break;
            case "Cleric":
                this.Texture = cleTex;
                break;
            case "Ranger":
                this.Texture = ranTex;
                break;
            case "Phillip":
                this.Texture = ranTex;
                break;
            default:
                GD.Print("Error: Invalid Sprite");
                break;
        }
    }
}
