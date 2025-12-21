using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class QuestGetter : Area2D
{
	QuestSortingScene parent;
	public override void _Ready()
	{
		parent = (QuestSortingScene)GetParent();
	}

	public override void _Process(double delta)
	{
		Position = GetGlobalMousePosition();
		int count = GetOverlappingBodies().Count;

		if (count == 0){/* No collisons, leave empty. */}
		else if (count == 1)
		{
			foreach(MoveableQuest b in parent.questStack)
			{
				b.notChosen();
			}
			MoveableQuest quest = (MoveableQuest)GetOverlappingBodies()[0];
			quest.isChosen();

			if (Input.IsActionJustPressed("mouse_click"))
			{
				parent.PushQuestToTop((MoveableQuest)GetOverlappingBodies()[0]);
			}
		}
		else
		{
			int maxIndex = -1;
			MoveableQuest topPaper = null;
			foreach (MoveableQuest b in GetOverlappingBodies())
			{
				if (b.ZIndex > maxIndex)
				{
					maxIndex = b.ZIndex;
					topPaper = b;
				}
			}
			topPaper.isChosen();
			foreach (MoveableQuest b in GetOverlappingBodies())
			{
				if (b != topPaper)
				{
					b.notChosen();
				}
			}
			if (Input.IsActionJustPressed("mouse_click"))
			{
				parent.PushQuestToTop(topPaper);
			}
		}
	}
}
