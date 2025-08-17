using Godot;
using System;

public partial class Player : CharacterBody2D
{
	float speed = 250;
	public Vector2 direction = new Vector2();
	private Sprite2D playerSprite;
	public void GetInput()
	{
		var input_direction = Input.GetVector("left", "right", "up", "down");
		direction = input_direction;
		Velocity = input_direction * speed;
	}

	public override void _Ready()
	{
		if (PlayerStats.Instance.isInside)
		{
			this.Position = PlayerStats.Instance.playerLocationInterior;
		}
		else
		{
			this.Position = PlayerStats.Instance.playerLocationExterior;
		}
    }


	public override void _Process(double delta)
	{
		GetInput();
		MoveAndSlide();
		if (!PlayerStats.Instance.isInside)
		{
			PlayerStats.Instance.playerLocationExterior = this.Position;
		}
		else
		{
			PlayerStats.Instance.playerLocationInterior = this.Position;
		}
	}
}
