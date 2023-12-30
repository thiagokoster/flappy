using Godot;

public partial class GameRunning : State
{
    public override void Enter()
    {
        GD.Print("The game is running!");
    }

    public override void Exit(){}

    public override void PhysicsUpdate(double delta)
    {
        if (Input.IsActionJustPressed("menu"))
		{
            EmitSignal(SignalName.Transitioned, this, "gamepaused");
		}
    }

    public override void Update(){}
}