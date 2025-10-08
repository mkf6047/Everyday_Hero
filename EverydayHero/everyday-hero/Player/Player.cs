using Godot;
using System;

public partial class Player : CharacterBody2D
{
	float speed = 250;
	public Vector2 direction = new Vector2();
	private Vector2 zero = new Vector2(0,0);
	private AnimatedSprite2D playerSprite;
	public override void _Ready()
	{
		playerSprite = (AnimatedSprite2D)GetNode("PlayerSpriteAni");
		//this.Position = PlayerStats.Instance.playerLocation;
    }

	public void GetInput()
	{
		var input_direction = Input.GetVector("left", "right", "up", "down");
		direction = input_direction;
		Velocity = input_direction * speed;
		if (direction == zero) { playerSprite.Play("Standing"); }
		else { playerSprite.Play("Walking"); }
	}

	public override void _Process(double delta)
	{
		GetInput();
		MoveAndSlide();
		PlayerStats.Instance.playerLocation = this.Position;
	}
}
