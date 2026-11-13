using UnityEngine;

public class StateMachine
{
    public State currentState;
    public void Initialize(State initialState)
    {
        currentState = initialState;
        initialState.EnterState();
    }
    public void ChangeState(State newState)
    {
        if (newState == currentState) return;
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
