using UnityEngine;

public class HiddenPlatform : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}
