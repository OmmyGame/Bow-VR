using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1.0f; // The interval between enemy spawns
    public float spawnRadius = 5.0f; // The maximum distance from the center of the spawner where enemies can spawn

    private float spawnTimer = 0.0f; // The timer for spawning enemies

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // If the spawn timer exceeds the spawn interval, spawn a new enemy
        if (spawnTimer >= spawnInterval)
        {
            // Reset the spawn timer
            spawnTimer = 0.0f;

            // Calculate a random position within the spawn radius
            Vector3 spawnPosition = (Random.onUnitSphere * spawnRadius) + transform.position;

            // Spawn the enemy at the calculated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
    private void OnDrawGizmos() 
    {
        // Draw a sphere at the center of the spawner with a radius equal to the spawn radius
        Gizmos.DrawWireSphere(transform.position,spawnRadius);
    }
}
