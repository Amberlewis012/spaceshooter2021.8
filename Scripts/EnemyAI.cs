using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    static List<Rigidbody2D> EnemyRBs;

    public float speed = 350f;
    public float nextWaypointDistance = 2f;

    [Range(0f, 1f)]
    public float turningSpeed = 0.3f;

    public float repelRange = 5f;
    public float repelAmount = 20f;
    public float playerRepelRange = 5f;
    public float playerRepelAmount = 20f;
    public float wallColliderRadius = 5f;
    public float wallRepelAmount = 20f;

    Rigidbody2D rb;
    Rigidbody2D playerRB;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }
        EnemyRBs.Add(rb);
    }

    private void OnDestroy()
    {
        EnemyRBs.Remove(rb);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (playerRB.position - rb.position).normalized;
        Vector2 newPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        newPos = Move(direction);
        newPos -= rb.position;
        rb.AddForce(newPos, ForceMode2D.Force);
    }
    Vector2 Move(Vector2 direction)
    {
        Vector2 repelForce = Vector2.zero;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, wallColliderRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("WallObstacles"))
            {
                
            }
        }

        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
            {
                continue;
            }
            if ((enemy.position - rb.position).sqrMagnitude <= repelRange * repelRange)
            {
                Vector2 repelDirection = (rb.position - enemy.position).normalized;
                repelForce += repelDirection;
            }
            if ((rb.position - playerRB.position).sqrMagnitude <= playerRepelRange * playerRepelRange)
            {
                Vector2 playerRepelDirection = (rb.position - playerRB.position).normalized;
                repelForce += playerRepelDirection;
            }
        }
        float totalRepelAmount = playerRepelAmount + repelAmount;

        Vector2 newPos = transform.position + transform.up * Time.fixedDeltaTime * speed;
        newPos += repelForce * Time.fixedDeltaTime * totalRepelAmount;

        return newPos;
    }
}
