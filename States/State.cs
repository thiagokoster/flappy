using Godot;
public abstract partial class State : Node
{

    [Signal]
	public delegate void TransitionedEventHandler(State state, string newStateName);
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void PhysicsUpdate(double delta);

}