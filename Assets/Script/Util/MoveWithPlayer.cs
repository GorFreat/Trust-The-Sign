using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 startPos;
    private Vector3 endPos;
    [SerializeField] private Vector3 distance;
    [SerializeField] private MovingType type;
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + distance;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, endPos) <= 0.1f)
        {
            Vector3 newTarget = startPos;
            startPos = endPos;
            endPos = newTarget;
            speed = -speed;
        }
        if (type == MovingType.Horizontal)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (type == MovingType.Vertical)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        else if (type == MovingType.Diagonal)
        {
            transform.position += new Vector3(speed, speed, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + distance);
    }
}
