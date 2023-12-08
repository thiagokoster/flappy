using System;
using Godot;

public partial class PlayerFlying : State 
{
	[Export]
	private CharacterBody2D player;
	private float _gravity = 600.0f;
	private float _jumpSpped = -400.0f;
	public override void _Ready()
	{
	}

    public override void Enter()
    {
        GD.Print($"Player is flying!");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }

    public override void PhysicsUpdate(double delta)
    {
		if (player is null)
		{
			return;
		}

		var velocity = player.Velocity;

		// Add gravity
		velocity.Y += (float)delta * _gravity;

		if (Input.IsActionPressed("jump"))
		{
			velocity.Y = _jumpSpped;
		}
		player.Velocity = velocity;

		var motion = velocity * (float)delta;
		var rightTestMotion = Vector2.Right * (float)delta * 200.0f;
		var collision = player.MoveAndCollide(motion) ?? player.MoveAndCollide(rightTestMotion, testOnly: true);
		if(collision != null)
		{
			GD.Print("Collision");
		}
    }

}
