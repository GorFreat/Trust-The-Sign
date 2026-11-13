using System.Collections;
using UnityEngine;

public class TrickTrap : MonoBehaviour
{
    [Header("First move when player reach trigger zone")]
    [SerializeField] private Vector3 firstDistance;
    [SerializeField] private float firstSpeed = 5f;

    [Header("Second move to trick player afer first move")]
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private Vector3 secondDistance;
    [SerializeField] private float secondSpeed = 8f;

    private bool canMove = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canMove)
            {
                StartCoroutine(TrapSequenceRoutine());
                canMove = false;
            }
        }
    }
    private IEnumerator TrapSequenceRoutine()
    {
        Vector3 startPos = transform.position;
        Vector3 firstTarget = startPos + firstDistance;

        while(Vector3.Distance(transform.position , firstTarget) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, firstTarget, firstSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = firstTarget;

        yield return new WaitForSeconds(waitTime);

        Vector3 finalTarget = transform.position + secondDistance;
        while (Vector3.Distance(transform.position, finalTarget) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalTarget, secondSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = finalTarget;
    }
    
    public void TrapSequence()
    {
        if (canMove)
        {
            StartCoroutine(TrapSequenceRoutine());
            canMove = false;
        }
    }
}
