using Godot;
using System;

public partial class LeaderSprite : Sprite2D
{
    Texture2D kniTex, magTex, monTex, rogTex, cleTex, ranTex, philTex;

    Sprite2D left, right, back;

    public override void _Ready()
    {
        kniTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Updated.png");
        magTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Wizard-Updated.png");
        monTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Monk-Updated.png");
        rogTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Rogue-Updated.png");
        cleTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Healer-Updated.png");
        ranTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Ranger-Updated.png");
        philTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Manager-Philip.png");
        left = (Sprite2D)GetNode("LeaderBckgndLeftEnd");
        right = (Sprite2D)GetNode("LeaderBckgndRightEnd");
        back = (Sprite2D)GetNode("LeaderBackground");
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
    public void Collision()
    {
        left.Texture = GD.Load<Texture2D>("res://Sprites/OverlaySprites/BoxSelected.png");
        right.Texture = GD.Load<Texture2D>("res://Sprites/OverlaySprites/BoxSelected.png");
        back.Texture = GD.Load<Texture2D>("res://Sprites/OverlaySprites/CenterSelected.png");
    }

    public void NoCollision()
    {
        left.Texture = GD.Load<Texture2D>("res://Sprites/OverlaySprites/TextboxEnd.png");
        right.Texture = GD.Load<Texture2D>("res://Sprites/OverlaySprites/TextboxEnd.png");
        back.Texture = GD.Load<Texture2D>("res://Sprites/OverlaySprites/TextboxCenter.png");
    }
}
