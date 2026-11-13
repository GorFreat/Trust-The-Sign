using TMPro;
using UnityEngine;

public class AdviceAppearController : MonoBehaviour
{
    private TextMeshPro text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }
    void Start()
    {
        text.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }
}
