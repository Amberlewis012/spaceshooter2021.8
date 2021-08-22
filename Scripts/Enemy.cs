using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int damage = 50;
    public int baseWallDamage = 20;
    public int selfHitDamage = 5;
    // public int reward = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            base.Die();
        }
        if (collision.collider.CompareTag("WallObstacles"))
        {
            base.TakeDamage(baseWallDamage);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            base.TakeDamage(selfHitDamage);
        }
    }
}
