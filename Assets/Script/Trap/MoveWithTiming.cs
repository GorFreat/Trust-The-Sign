using System.Collections;
using UnityEngine;

public class MoveWithTiming : MonoBehaviour
{
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float speed;

    private bool canMove = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canMove)
        {
            StartCoroutine(TimingMove());
            canMove = false;
        }
    }

    private IEnumerator TimingMove()
    {
        yield return new WaitForSeconds(waitTime);

        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + distance;
        while(Vector3.Distance(transform.position, endPos) < 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = endPos;
    }
}
