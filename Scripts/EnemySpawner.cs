using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;
    public float spawnDelay;

    public float spawnRadius = 15f;
    public Rigidbody2D playerRB;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }
    void SpawnEnemy()
    {
        Vector2 spawnPosition = playerRB.position;
        spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
