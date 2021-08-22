using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public int baseWallDamage = 20;
    public TextMeshProUGUI healthText;

    public override void Die()
    {
        healthText.text = "HEALTH: 0";
        GameManager.instance.PlayerDeath();
        base.Die();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WallObstacles"))
        {
            base.TakeDamage(baseWallDamage);
        }
    }
    private void Update()
    {
        int playerHealth = this.health;
        healthText.text = "HEALTH: " + playerHealth.ToString();
    }
}
