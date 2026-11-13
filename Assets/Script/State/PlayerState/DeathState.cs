using UnityEngine;

public class DeathState : State
{
    private PlayerController player;
    public DeathState(StateMachine stateMachine, PlayerController player) : base(stateMachine)
    {
        this.player = player;
    }

    public override void EnterState()
    {
        base.EnterState();
        player._animator.SetBool("isDie", true);
        player.gameObject.layer = LayerMask.NameToLayer("Corpse");
        player._rb.gravityScale = 0f;
        player._rb.linearVelocity = Vector2.zero;
        GameManager.Instance.StartCoroutine(GameManager.Instance.RespawRoutine(player, 0.5f));
    }

    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
        player._animator.SetBool("isDie", false);
    }

}
