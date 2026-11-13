using System.Collections;
using UnityEngine;

public class TimedTrap : MonoBehaviour
{
    [SerializeField] private float waitTimne = 5f;
    private SpriteRenderer spriteRenderer;
    private Collider2D trapCollider;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trapCollider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        spriteRenderer.enabled = false;
        trapCollider.enabled = false;
    }
    public void SetActiveTime()
    {
        StartCoroutine(AppearRoutine());
    }

    private IEnumerator AppearRoutine()
    {
        spriteRenderer.enabled = true;
        trapCollider.enabled = true;
        yield return new WaitForSeconds(waitTimne);
        spriteRenderer.enabled = false;
        trapCollider.enabled = false;
    }
}
