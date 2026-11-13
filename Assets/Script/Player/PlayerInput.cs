using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool _jumpCheck { get; private set; }
    public float _horizontal {  get; private set; }

    private InputSystem_Actions _controls;
    private void Awake()
    {
        _controls = new InputSystem_Actions();
    }
    private void Update()
    {
        _jumpCheck = _controls.Player.Jump.WasPressedThisFrame();
        _horizontal = _controls.Player.Move.ReadValue<Vector2>().x;
    }
    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }
}
