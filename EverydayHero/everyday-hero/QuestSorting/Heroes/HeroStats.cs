using Godot;
using System;

public partial class HeroStats : Node
{
    public string heroClass = "";
    public string heroRank = "F";
    public Godot.Collections.Array<string> currentQuestsTypes = new Godot.Collections.Array<string>(); //
    public Godot.Collections.Array<string> currentQuestsNames = new Godot.Collections.Array<string>();
    public Godot.Collections.Array<int> questCompletionRewards = new Godot.Collections.Array<int>();
    public Godot.Collections.Dictionary<string, int> completionByRank = new Godot.Collections.Dictionary<string, int>
    {
        {"SSS", 0},
        {"SS", 0},
        {"S", 0},
        {"A", 0},
        {"B", 0},
        {"C", 0},
        {"D", 0},
        {"E", 0},
        {"F", 0},
    };
    public bool onQuest = false;
    public int daysRemainingOnQuest = 0;
    public int goodbadprogress = 0;
    public Sprite2D sprite = new Sprite2D();
}
