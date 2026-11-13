using UnityEngine;

public class PlayerCloneController : MonoBehaviour
{
    [SerializeField] private AnimationClip idleClip;
    [SerializeField] private AnimationClip dieClip;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.Play("p_idle");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            animator.Play("p_die");
        }
    }
}
