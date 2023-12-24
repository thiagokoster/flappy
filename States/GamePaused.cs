using System.Threading;
using Godot;

public partial class GamePaused : State
{
    [Export]
    private RichTextLabel text;
    public override void Enter()
    {
        text.Show();
        GetTree().Paused = true;
    }

    public override void Exit()
    {
        text.Hide();
        GetTree().Paused = false;
    }

    public override void PhysicsUpdate(double delta)
    {

        if (Input.IsActionJustPressed("menu"))
		{
            EmitSignal(SignalName.Transitioned, this, "gamerunning");
		}
    }

    public override void Update()
    {
    }
}