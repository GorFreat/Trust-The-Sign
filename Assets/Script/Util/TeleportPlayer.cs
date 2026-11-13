using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    public void Teleport()
    {
        player.transform.position = transform.position;
    }
}
