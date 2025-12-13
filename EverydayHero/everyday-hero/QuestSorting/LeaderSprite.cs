using Godot;
using System;

public partial class LeaderSprite : Sprite2D
{
    Texture2D kniTex, magTex, monTex, rogTex, cleTex, ranTex, philTex;

    Sprite2D left, right, back, speakerSprite;

    ChangeColorCollide collisionDetection;

    public override void _Ready()
    {
        kniTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Knight-Frame.png");
        magTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Wizard-Frame.png");
        monTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Monk-Frame.png");
        rogTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Rogue-Frame.png");
        cleTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Healer-Frame.png");
        ranTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Ranger-Frame.png");
        philTex = GD.Load<Texture2D>("res://Sprites/NPCSprites/Philip-Frame.png");
        left = (Sprite2D)GetNode("LeaderBckgndLeftEnd");
        right = (Sprite2D)GetNode("LeaderBckgndRightEnd");
        back = (Sprite2D)GetNode("LeaderBackground");
        speakerSprite = (Sprite2D)GetNode("../SpeakerSprite");
        collisionDetection = (ChangeColorCollide)GetNode("ChangeColorCollide");
        ConcealActiveHero();
    }

    public void RevealActiveHero()
    {
        this.Show();
    }

    public void ConcealActiveHero()
    {
        this.Hide();
    }

    public void ReplaceSprite(string charClass)
    {
        switch (charClass)
        {
            case "Knight":
                this.Texture = kniTex;
                speakerSprite.Texture = kniTex;
                break;
            case "Mage":
                this.Texture = magTex;
                speakerSprite.Texture = magTex;
                break;
            case "Monk":
                this.Texture = monTex;
                speakerSprite.Texture = monTex;
                break;
            case "Rogue":
                this.Texture = rogTex;
                speakerSprite.Texture = rogTex;
                break;
            case "Cleric":
                this.Texture = cleTex;
                speakerSprite.Texture = cleTex;
                break;
            case "Ranger":
                this.Texture = ranTex;
                speakerSprite.Texture = ranTex;
                break;
            case "Phillip":
                this.Texture = philTex;
                speakerSprite.Texture = philTex;
                break;
            default:
                GD.Print("Error: Invalid Sprite");
                break;
        }
        collisionDetection.UpdateClassInfo(charClass);
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
