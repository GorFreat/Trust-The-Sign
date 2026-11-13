using System.Collections;
using UnityEngine;

public class TimingBlink : MonoBehaviour
{
    [SerializeField] private float waitTime;
    private Collider2D trapCollider;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        trapCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        trapCollider.enabled = false;
    }

    public void Blink()
    {
        StartCoroutine(WaitBlinkCoroutine());
    }

    private IEnumerator WaitBlinkCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        trapCollider.enabled = true;
    }
}
