using UnityEngine;
using UnityEngine.Events;

public class TrapTrigger : MonoBehaviour
{
    public UnityEvent triggerEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerEvent?.Invoke();
        }
    }
}
