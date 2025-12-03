using Godot;
using System;

public partial class MovingProgressReport : CharacterBody2D
{
    [Export]
    string QuesterName;
	Sprite2D sprite;
	Vector2 newPosition;
    Vector2 dir;
	ProgressData data;
	AllPartyProgressReport removalHub;
	float draggingDistance;
	bool dragging;
	bool mouseIn = false;
	public bool chosen = false;
	public int questReward, thisQuester, failChance = 0;
	public bool Dragging
	{
		get { return dragging; }
	}
	public override void _Ready()
	{
        sprite = (Sprite2D)GetNode("QuestSprite");
		data = (ProgressData)GetNode("ProgressData");
		removalHub = (AllPartyProgressReport)GetNode("../../");
        switch (QuesterName)
        {
            case "Knight":
				data.UpdateName("Allistrad von Leopold");
				thisQuester = 0;
				if(!PartyLists.Instance.parties[0][0].onQuest){ removalHub.CallDeferred("RemoveReport", this); }
				break;
			case "Mage":
                data.UpdateName("Lucy Fern");
				thisQuester = 2;
				if(!PartyLists.Instance.parties[0][2].onQuest){ removalHub.CallDeferred("RemoveReport", this); }
				break;
			case "Monk":
                data.UpdateName("Rashao Kahan");
				thisQuester = 3;
				if(!PartyLists.Instance.parties[0][3].onQuest){ removalHub.CallDeferred("RemoveReport", this); }
				break;
			case "Rogue":
                data.UpdateName("Jack Decker");
				thisQuester = 5;
				if(!PartyLists.Instance.parties[0][5].onQuest){ removalHub.CallDeferred("RemoveReport", this); }
				break;
			case "Cleric":
                data.UpdateName("Rosalind Deacon");
				thisQuester = 1;
				if(!PartyLists.Instance.parties[0][1].onQuest){ removalHub.CallDeferred("RemoveReport", this); }
				break;
			case "Ranger":
                data.UpdateName("Thornton Breyer");
				thisQuester = 4;
				if(!PartyLists.Instance.parties[0][4].onQuest){ removalHub.CallDeferred("RemoveReport", this); }
				break;
            default:
                data.UpdateName("unknown");
				thisQuester = 0;
				break;
        }
		PartyLists.Instance.CalculateFailure(thisQuester);
		data.UpdateProgress(thisQuester, PartyLists.Instance.parties[0][thisQuester].goodbadprogress[0]);
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
		sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestSelected.png");
	}

	public virtual void MouseExit()
	{
		mouseIn = false;
		sprite.Texture = GD.Load<Texture2D>("res://Sprites/QuestSprites/QuestPaper.png");
	}
}
