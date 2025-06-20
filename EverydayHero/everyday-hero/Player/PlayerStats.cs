using Godot;
using System;

public partial class PlayerStats : Node
{
    private int coins = 0;
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
}
