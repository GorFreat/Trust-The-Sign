using System.Collections;
using UnityEngine;

public class TriggerMove : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _distance;

    public bool canMove = true;
    [SerializeField] private bool moveByButton = false;


    void Start()
    {
        _startPos = transform.position;
        _endPos = _startPos + _distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canMove && !moveByButton)
        {
            StartCoroutine(Move());
            canMove = false;
        }
    }
    public IEnumerator Move()
    {
        while(Vector3.Distance(transform.position, _endPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPos, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = _endPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + _distance);
    }

    public void TriggerButtonMove()
    {
        if (canMove && moveByButton)
        {
            canMove = false;
            StartCoroutine(Move());
        }
    }

}
