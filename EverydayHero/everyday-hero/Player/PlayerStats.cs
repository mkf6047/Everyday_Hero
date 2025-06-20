using Godot;
using System;

public partial class PlayerStats : Node
{
    public static PlayerStats Instance { get; private set; }
    private int coins = 0;
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    public override void _Ready()
    {
        Instance = this;
    }

}
