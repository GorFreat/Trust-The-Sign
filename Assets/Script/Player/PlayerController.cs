using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field:SerializeField] public float _moveSpeed { get; private set;} = 8f;
    [field:SerializeField] public float _jumpPower { get; private set;} = 16f;


    public Rigidbody2D _rb { get; private set; }
    public Animator _animator { get; private set; }
    public PlayerInput _playerInput { get; private set; }

    #region
    public State idleState {  get; private set; }
    public State runState { get; private set; }
    public State jumpState { get; private set; }
    public State dieState {  get; private set; }

    [field:SerializeField] public bool groundCheck {get; private set;}
    #endregion

    private StateMachine _machine;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _machine = new StateMachine();

        idleState = new IdleState(_machine, this);
        runState = new RunState(_machine, this);
        jumpState = new jumpState(_machine, this);
        dieState = new DeathState(_machine, this);
    }
    void Start()
    {
        _machine.Initialize(idleState);
    }

    void Update()
    {
        _machine.currentState.LogicUpdateState();
    }
    private void FixedUpdate()
    {
        Flip();
        _machine.currentState.PhysicalUpdate();
    }

    private void Flip()
    {
        if(Mathf.Abs(_playerInput._horizontal) > 0.1f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * _playerInput._horizontal < 0 ? -1f : 1f;
            transform.localScale = localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = true;
            SoundManager.PlaySound(SoundType.LAND);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            _machine.ChangeState(dieState);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }
    }

    public void RespawnToIdle()
    {
        _machine.ChangeState(idleState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
        }
    }
}
