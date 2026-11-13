using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 100;
    void Update()
    {
        transform.Rotate(new Vector3(0,0, _rotateSpeed * Time.deltaTime));
    }
}
