using UnityEngine;
using UnityEngine.Events;

public class TriggerButtonScript : MonoBehaviour
{
    [SerializeField] private Sprite pressedButtonSprite;
    private SpriteRenderer ButtonSprite;

    [Header("Envent active when button being pressed")]
    public UnityEvent onButtonPressed;
    private bool isPressed = false;

    private void Awake()
    {
        ButtonSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isPressed)
        {
            SoundManager.PlaySound(SoundType.MOUSE_CLICK);
            isPressed = true;
            ButtonSprite.sprite = pressedButtonSprite;
            onButtonPressed?.Invoke();
        }
    }

}
