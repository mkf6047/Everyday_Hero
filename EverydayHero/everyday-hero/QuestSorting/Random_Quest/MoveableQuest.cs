using Godot;
using System;

public partial class MoveableQuest : CharacterBody2D
{
	Sprite2D sprite, completeMark, continueMark;
	QuestData data;
	Vector2 newPosition;
	Vector2 dir;
	float draggingDistance;
	bool dragging, canChange = true;
	bool mouseIn = false;
	public bool isComplete = false, needHelp = false;
	public bool chosen = false;
	public int questReward, questDuration = 0, heroInNeed = -1;
	public string questName, questType, questRank = "";
	public string[] bestHeroes = [];
	public bool Dragging
	{
		get { return dragging; }
	}
	public override void _Ready()
	{
		sprite = (Sprite2D)GetNode("QuestSprite");
		data = (QuestData)GetNode("QuestData");
		completeMark = (Sprite2D)GetNode("Complete");
		continueMark = (Sprite2D)GetNode("InProgress");
		completeMark.Hide();
		continueMark.Hide();
	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("mouse_click"))
		{
			if (chosen && mouseIn)
			{
				draggingDistance = Position.DistanceTo(GetViewport().GetMousePosition());
				dir = (GetViewport().GetMousePosition() - Position).Normalized();
				dragging = true;
				newPosition = GetViewport().GetMousePosition() - draggingDistance * dir;
			}
			else
			{
				dragging = false;
				chosen = false;
			}
		}
		else if (@event.IsActionReleased("mouse_click"))
		{
			dragging = false;
		}
		else if (@event is InputEventMouseMotion)
		{
			if (dragging)
			{
				newPosition = GetViewport().GetMousePosition() - draggingDistance * dir;
			}
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (dragging)
		{
			Velocity = (newPosition - Position) * new Vector2(30, 30);
			MoveAndSlide();
		}
		if(chosen && mouseIn && canChange)
		{
			sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestSelected.png");
			canChange = false;
		}
		else if (!chosen || !mouseIn)
		{
			sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestPaper.png");
		}
	}

	public void isChosen()
	{
		chosen = true;
	}

	public void notChosen()
	{
		chosen = false;
	}

	public virtual void MouseEnter()
	{
		mouseIn = true;
		canChange = true;
		//if(chosen){ sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestSelected.png"); }
	}

	public virtual void MouseExit()
	{
		mouseIn = false;
		sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestPaper.png");
	}

	public void SpecificQuest(string filepath)
    {
        data.SpecificQuest(filepath);
    }

	public void Completed()
	{
		completeMark.Show();
		isComplete = true;
	}

	public void NeedsWork(int heroToHelp)
	{
		continueMark.Show();
		needHelp = true;
		heroInNeed = heroToHelp;
	}
}
