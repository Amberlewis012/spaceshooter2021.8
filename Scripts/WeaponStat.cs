using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponStat : ScriptableObject
{
    public GameObject bulletPrefab;
    public float fireRate;

    public void Shoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 10f);
    }
}
