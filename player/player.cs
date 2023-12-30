using Godot;

public partial class player : CharacterBody2D
{
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var vel = Velocity;
		vel += Vector2.Right * 300;
		Rotation = vel.Angle();
		QueueRedraw();
	}
}
