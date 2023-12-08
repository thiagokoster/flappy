using Godot;
using System;

public partial class obstacle : StaticBody2D 
{

	[Signal]
	public delegate void PlayerCollidedEventHandler();
	private float _speed = 200.0f;
	
	public override void _PhysicsProcess (double delta)
	{
		var motion = Vector2.Left * (float)delta * _speed;
		MoveAndCollide(motion);
	}
}
