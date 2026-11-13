using Unity.VisualScripting;
using UnityEngine;

public class jumpState : State
{
    private PlayerController player;
    private bool groundCheck;
    public jumpState(StateMachine stateMachine, PlayerController player) : base(stateMachine)
    {
        this.player = player;
    }

    public override void EnterState()
    {
        base.EnterState();
        player._animator.SetBool("isJumping", true);
        Jump();
    }
    public override void ExitState()
    {
        base.ExitState();
        player._animator.SetBool("isJumping", false);
    }
    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
        if (player.groundCheck && player._rb.linearVelocityY < 0.1f)
        {
            if(Mathf.Abs(player._playerInput._horizontal) < 0.1f)
            {
                stateMachine.ChangeState(player.idleState);
                return;
            }
            else if(Mathf.Abs(player._playerInput._horizontal) > 0.1f)
            {
                stateMachine.ChangeState(player.runState);
                return;
            }
        }
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
        float moveDir = player._playerInput._horizontal;
        player._rb.linearVelocityX = moveDir * player._moveSpeed;
    }
    
    private void Jump()
    {
        player._rb.linearVelocityY = player._jumpPower;
    }
}
