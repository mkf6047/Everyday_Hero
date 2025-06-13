using Godot;
using System;
using System.Linq;

public partial class QuestSortingScene : Node2D
{
    Godot.Collections.Array<MoveableQuest> questStack = [];

    PackedScene questPreload = GD.Load<PackedScene>("");

    public override void _Ready()
    {
        for (int i = 0; i <= 2; i++)
        {
            MoveableQuest quest = (MoveableQuest)questPreload.Instantiate();
            AddQuest(quest);
        }
    }

    //press Interact Button (Z or Enter) to move to the save files
    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("Interact"))
        {
            GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
        }
        if (questStack.Count() <= 0)
        {
            GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
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
    }

    public void PushQuestToTop(MoveableQuest quest)
    {
        questStack.Remove(quest);
        AddQuest(quest);
    }

    public void RemoveQuest(MoveableQuest quest)
    {
        questStack.Remove(quest);
        quest.QueueFree();
    }
}
