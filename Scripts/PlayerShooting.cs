using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public WeaponStat currentWeapon;

    float nextTimeToFire = 0f;

    [HideInInspector]
    public bool hasShot = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
