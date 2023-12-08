using Godot;
using System;

public partial class obstacle : StaticBody2D 
{

	[Signal]
	public delegate void PlayerCollidedEventHandler();
	private float _speed = 200.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess (double delta)
	{
		var motion = Vector2.Left * (float)delta * _speed;
		var collision = MoveAndCollide(motion);
		// if (collision != null)
		// {
		// 	GD.Print("I collided!");
		// }
	}

	public void OnBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.PlayerCollided);
	}
}
