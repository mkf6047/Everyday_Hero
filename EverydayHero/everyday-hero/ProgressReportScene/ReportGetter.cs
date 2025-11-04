using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class ReportGetter : Area2D
{
	AllPartyProgressReport parent;
	public override void _Ready()
	{
		parent = (AllPartyProgressReport)GetParent();
	}

	public override void _Process(double delta)
	{
		Position = GetGlobalMousePosition();
		int count = GetOverlappingBodies().Count;

		if (count == 0)
		{
		}
		else if (count == 1)
		{
			MovingProgressReport quest = (MovingProgressReport)GetOverlappingBodies()[0];
			quest.isChosen();

			if (Input.IsActionJustPressed("mouse_click"))
			{
				parent.PushReportToTop((MovingProgressReport)GetOverlappingBodies()[0]);
			}
		}
		else
		{
			int maxIndex = -1;
			MovingProgressReport topPaper = null;
			foreach (MovingProgressReport b in GetOverlappingBodies())
			{
				if (b.ZIndex > maxIndex)
				{
					maxIndex = b.ZIndex;
					topPaper = b;
				}
			}
			topPaper.isChosen();
			foreach (MovingProgressReport b in GetOverlappingBodies())
			{
				if (b != topPaper)
				{
					b.notChosen();
				}
			}
			if (Input.IsActionJustPressed("mouse_click"))
			{
				parent.PushReportToTop(topPaper);
			}
		}
	}
}
