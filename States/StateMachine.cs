
using System.Collections.Generic;
using Godot;
public partial class StateMachine : Node 
{
    [Export]
    private State initialState;
   private readonly Dictionary<string, State> states = new();
   private State currentState;
    public override void _Ready()
	{
        GD.Print("Initializing StateMachine");
        GD.Print($"found {GetChildren().Count} children");
        foreach(var childNode in GetChildren()) 
        {
            if (childNode is State child)
            {
                GD.Print($"Adding {child.Name.ToString().ToLower()} to state machine");
                states[child.Name.ToString().ToLower()] = child;
                child.Transitioned += OnChildTransitioned;
            }
        }
        if (initialState is not null)
        {
            initialState.Enter();
            currentState = initialState;
        }
	}

    public override void _Process(double delta)
    {
        currentState?.Update();
    }

    public override void _PhysicsProcess(double delta)
    {
        currentState?.PhysicsUpdate(delta);
    }

    private void OnChildTransitioned(State state, string newStateName)
    {
        if (state != currentState)
        {
            return;
        }

        if(!states.TryGetValue(newStateName.ToLower(), out var newState))
        {
            return;
        }

        currentState?.Exit();
        newState.Enter();
        currentState = newState;
    }
}