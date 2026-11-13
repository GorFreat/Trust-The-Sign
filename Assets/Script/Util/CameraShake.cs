using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource _impulseSource;
    private bool shaking = false;

    [Header("Độ mạnh của lực rung (Nên để từ 0.05 đến 0.15)")]
    [SerializeField] private float shakeForce = 0.08f;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        if (shaking && _impulseSource != null)
        {
            Vector3 randomVelocity = new Vector3(
                Random.Range(-shakeForce, shakeForce),
                Random.Range(-shakeForce, shakeForce),
                0f
            );
            _impulseSource.GenerateImpulseWithVelocity(randomVelocity);
        }
    }

    public void StartShake()
    {
        shaking = true;
        SoundManager.PlaySound(SoundType.EARTH_QUAKE);
    }

    public void StopShake()
    {
        shaking = false;
    }
}