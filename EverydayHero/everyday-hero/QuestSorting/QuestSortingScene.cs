using Godot;
using System;
using System.Collections.Specialized;
using System.Linq;

public partial class QuestSortingScene : Node2D
{
    Godot.Collections.Array<MoveableQuest> questStack = [];

    PackedScene questPreload = GD.Load<PackedScene>("res://QuestSorting/Random_Quest/RandomQuest.tscn");

    bool readyComplete = false;

    int numofquest = 0;

    public override void _Ready()
    {
        for (int i = 0; i <= 2; i++)
        {
            MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
            AddChild(quest);
            quest.Position = new Vector2((i + 1) * 200, 400);
            AddQuest(quest);
        }
        readyComplete = true;
    }

    //press Interact Button (Z or Enter) to move to the save files
    public override void _Process(double delta)
    {
        if ((numofquest <= 0) && readyComplete)
        {
            GetTree().CallDeferred("change_scene_to_file", "res://Maps/ExteriorMaps/MainScene.tscn");
        }
    }

    public void AddQuest(MoveableQuest quest)
    {
        questStack.Append(quest);

        int count = 0;
        foreach (MoveableQuest q in questStack)
        {
            q.ZIndex = count;
            count++;
        }
        numofquest++;
    }

    public void PushQuestToTop(MoveableQuest quest)
    {
        questStack.Remove(quest);
        AddQuest(quest);
        numofquest--;
    }

    public void RemoveQuest(MoveableQuest quest)
    {
        questStack.Remove(quest);
        RemoveChild(quest);
        quest.QueueFree();
        numofquest--;
    }
}
