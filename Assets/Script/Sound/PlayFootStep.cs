using UnityEngine;

public class PlayFootStep : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float volume = 1f;
    public void PlaySound()
    {
        SoundManager.PlaySound(SoundType.FOOTSTEP, volume);
    }
}
