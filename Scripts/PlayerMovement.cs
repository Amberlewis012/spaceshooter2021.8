using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float shootingForce = 60f;

    public PlayerShooting shootingScript;

    private void Update()
    {
        Vector2 mousePosition = Vector2.zero;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - rb.position;
        lookDirection = lookDirection.normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (shootingScript.hasShot)
        {
            rb.AddForce(-lookDirection * shootingForce);
        }
    }
}
