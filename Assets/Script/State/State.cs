using Unity.VisualScripting;
using UnityEngine;

public class State
{
    protected float _startTime;
    protected float _stateTime => Time.time - _startTime;
    protected StateMachine stateMachine;
    public State(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void EnterState()
    {
        _startTime = Time.time;
    }
    public virtual void LogicUpdateState()
    {

    }
    public virtual void PhysicalUpdate()
    {

    }
    public virtual void ExitState()
    {

    }
}
