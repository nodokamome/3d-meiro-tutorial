using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3.0f;
    public float stopDistance = 2.0f;

    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= stopDistance && !isMoving)
        {
            targetPosition = playerTransform.position;
            isMoving = true;
        }

        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, playerTransform.position) <= stopDistance)
            {
                isMoving = false;
            }
        }
    }
}
