using Godot;
using System;

public partial class player : CharacterBody2D
{
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnCollision()
	{
		GD.Print("I collided!");
	}
}
