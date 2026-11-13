using UnityEngine;

public enum MovingType
{
    Horizontal,
    Vertical,
    Diagonal
}
public class AutoMove : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _distance;
    [SerializeField] private bool _backAndForth;

    [SerializeField] private MovingType _type;
    void Start()
    {
        _startPos = transform.position;
        _endPos = _startPos + _distance;
    }
    void Update()
    {
        if (_backAndForth)
        {
            MoveBackAndForth();
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        if (Vector3.Distance(transform.position, _endPos) < 0.5f) return;
        if (_type == MovingType.Horizontal)
        {
            transform.position += new Vector3(_speed, 0 , 0) * Time.deltaTime;
        }
        else if(_type == MovingType.Vertical)
        {
            transform.position += new Vector3(0, _speed, 0) * Time.deltaTime;
        }
        else if(_type == MovingType.Diagonal)
        {
            transform.position += new Vector3(_speed, _speed, 0) * Time.deltaTime;
        }
    }
    private void MoveBackAndForth()
    {
        if (Vector3.Distance(transform.position, _endPos) <= 0.5f)
        {
            Vector3 _newTarget = _startPos;
            _startPos = _endPos;
            _endPos = _newTarget;
            _speed = - _speed;
        }
        if (_type == MovingType.Horizontal)
        {
            transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;
        }
        else if (_type == MovingType.Vertical)
        {
            transform.position += new Vector3(0, _speed, 0) * Time.deltaTime;
        }
        else if (_type == MovingType.Diagonal)
        {
            transform.position += new Vector3(_speed, _speed, 0) * Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + _distance);
    }
}
