using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce = 60f;
    public int damage = 50;

    public bool enemyBullet = false;

    public GameObject hitEffect;

    Rigidbody2D rb;

    private void Start()
    {
        hitEffect.SetActive(false);
        
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WallObstacles") || collision.collider.CompareTag("Enemy"))
        {
            Remove();
        }
        if (!enemyBullet)
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Damage(enemy);
            }
        }
        else
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                Damage(player);
            }
        }
    }

    void Damage(Entity target)
    {
        if (target != null)
        {
            target.TakeDamage(damage);
        }
        Remove();
    }

    void Remove()
    {
        hitEffect.SetActive(true);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
