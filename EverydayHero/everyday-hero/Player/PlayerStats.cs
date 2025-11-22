using Godot;
using System;

public partial class PlayerStats : Node
{
    public static PlayerStats Instance { get; private set; }
    private int coins = 0;
    private int questsSorted = 0;
    private int daysPassed = 1;
    private double playtime = 0;
    private string rank = "Unemployed";
    private string playerName = "Reginald";
    private bool isPlaying = false;
    public bool isInside = false;
    public Godot.Collections.Array<string> inventory;
    public Godot.Collections.Array<int> inventoryPrice;
    public Vector2 playerLocation;
    private string currentScene = "res://Maps/BuildingInteriors/PlayerHouseInterior/PlayerHouse2f.cs";
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
    public int QuestsSorted
    {
        get { return questsSorted; }
        set { questsSorted = value; }
    }
    public int DaysPassed
    {
        get { return daysPassed; }
        set { daysPassed = value; }
    }
    public double Playtime
    {
        get { return playtime; }
        set { playtime = value; }
    }
    public string Rank
    {
        get { return rank; }
        set { rank = value; }
    }
    public string CurrentScene
    {
        get { return currentScene; }
        set { currentScene = value; }
    }
    public bool IsPlaying
    {
        get { return isPlaying; }
        set { isPlaying = value; }
    }
    
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }


    public override void _Ready()
    {
        inventory = new Godot.Collections.Array<string>();
        inventoryPrice = new Godot.Collections.Array<int>();
        playerLocation = new Vector2(0, 0);
        Instance = this;
    }
    public override void _Process(double delta)
    {
        if (isPlaying)
        {
            playtime += delta;
        }
    }
}
