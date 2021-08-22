using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public WeaponStat currentWeapon;

    float nextTimeToFire = 0f;

    GameObject player;
    public float shootingDistance = 7.5f;
    
    public float maxChaseDistance = 15f;

    [HideInInspector]
    public bool hasShot = false;

    private void Update()
    {
        Vector2 playerLocation = player.transform.position;
        Vector2 enemyLocation = this.transform.position;

        float distance = Vector2.Distance(enemyLocation, playerLocation);
        
        if (distance > maxChaseDistance && SceneManager.GetActiveScene().name != "Tutorial")
        {
            Destroy(gameObject);
            return;
        }
        if (distance < shootingDistance)
        {
            if (Time.time >= nextTimeToFire)
            {
                currentWeapon.Shoot(firePoint);
                hasShot = true;
                nextTimeToFire = Time.time + 1f / currentWeapon.fireRate;
            }
        }
        else
        {
            hasShot = false;
        }
    }
}
