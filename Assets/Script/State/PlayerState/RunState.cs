using UnityEngine;

public class RunState : State
{
    private PlayerController player;
    public RunState(StateMachine stateMachine, PlayerController player) : base(stateMachine)
    {
        this.player = player;
    }
    public override void EnterState()
    {
        base.EnterState();
        player._animator.SetBool("isRunning", true);
    }
    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
        if(Mathf.Abs(player._playerInput._horizontal) < 0.1f)
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        if (player._playerInput._jumpCheck)
        {
            stateMachine.ChangeState(player.jumpState);
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
        Move();
    }
    public override void ExitState()
    {
        base.ExitState();
        player._animator.SetBool("isRunning", false);
    }

    private void Move()
    {
        float moveDir = player._playerInput._horizontal;
        player._rb.linearVelocityX = moveDir * player._moveSpeed;
    }
}
