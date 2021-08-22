using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
