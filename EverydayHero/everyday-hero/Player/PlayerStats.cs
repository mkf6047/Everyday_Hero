using Godot;
using System;

public partial class PlayerStats : Node
{
    public static PlayerStats Instance { get; private set; }
    private int coins = 0;
    private float playtime = 0;
    private char rank = 'F';
    public Godot.Collections.Array<string> inventory;
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
    public float Playtime
    {
        get { return playtime; }
        set { playtime = value; }
    }
    public char Rank
    {
        get { return rank; }
        set { rank = value; }
    }


    public override void _Ready()
    {
        Instance = this;
    }

}
