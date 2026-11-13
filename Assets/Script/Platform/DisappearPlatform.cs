using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    public void dissapear()
    {
        gameObject.SetActive(false);
    }
}
