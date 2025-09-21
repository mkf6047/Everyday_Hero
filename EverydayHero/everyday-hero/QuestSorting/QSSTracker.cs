using Godot;
using System;

public partial class QSSTracker : Node
{
    public int acceptedQuests, delayedQuests, rejectedQuests, rewards = 0;
    public static QSSTracker Instance;
    public override void _Ready()
    {
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
