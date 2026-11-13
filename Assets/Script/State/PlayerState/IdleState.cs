using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    private PlayerController player;
    public IdleState(StateMachine stateMachine, PlayerController player) : base(stateMachine)
    {
        this.player = player;
    }

    public override void EnterState()
    {
        base.EnterState();
        player._animator.SetTrigger("isIdle");
    }
    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
        if(Mathf.Abs(player._playerInput._horizontal) > 0.1f)
        {
            stateMachine.ChangeState(player.runState);
            return;
        }
        if (player._playerInput._jumpCheck && player.groundCheck)
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
        player._rb.linearVelocityX = 0f;
    }
}
