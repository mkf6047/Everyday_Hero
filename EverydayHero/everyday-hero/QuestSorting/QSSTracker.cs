using Godot;
using System;

public partial class QSSTracker : Node
{
    public int acceptedQuests, delayedQuests, rejectedQuests, rewards = 0;

    public Godot.Collections.Dictionary<string, int> delayedQuestInfo;
    public Godot.Collections.Dictionary<string, Godot.Collections.Array<int>> delayedHelp;
    public static QSSTracker Instance;
    public override void _Ready()
    {
        delayedQuestInfo = new Godot.Collections.Dictionary<string, int>();
        delayedHelp = new Godot.Collections.Dictionary<string, Godot.Collections.Array<int>>();
        Instance = this;
    }

    public void ResetCounts()
    {
        acceptedQuests = 0;
        delayedQuests = 0;
        rejectedQuests = 0;
        rewards = 0;
    }
}
