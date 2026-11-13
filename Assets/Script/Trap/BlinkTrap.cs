using System.Collections;
using UnityEngine;

public class BlinkTrap : MonoBehaviour
{
    [SerializeField] private float blinkTime = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Collider2D trapCollider;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trapCollider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        trapCollider.enabled = false;
    }
    public void Blink()
    {
        StartCoroutine(BlinkObject());
    }

    private IEnumerator BlinkObject()
    {
        spriteRenderer.enabled = true;
        trapCollider.enabled = true;
        yield return new WaitForSeconds(blinkTime);
        spriteRenderer.enabled = false;
        trapCollider.enabled = false;
    }
}
