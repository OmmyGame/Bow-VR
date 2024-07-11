using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1.0f; // The interval between enemy spawns
    public float spawnRadius = 5.0f; // The maximum distance from the center of the spawner where enemies can spawn
    public float spawnRadiusMin = 1.0f; // The minimum distance from the center of the spawner where enemies can spawn
    public float minXAngle = -45f; // Minimum X angle in degrees
    public float maxXAngle = 45f; // Maximum X angle in degrees
    public float minYAngle = 0f; // Minimum Y angle in degrees
    public float maxYAngle = 90f; // Maximum Y angle in degrees

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

            // Calculate a random position within the spawn radius and angle limitations
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // Spawn the enemy at the calculated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

Vector3 GetRandomSpawnPosition()
{
    // Convert angle limits from degrees to radians
    float minXAngleRad = minXAngle * Mathf.Deg2Rad;
    float maxXAngleRad = maxXAngle * Mathf.Deg2Rad;
    float minYAngleRad = minYAngle * Mathf.Deg2Rad;
    float maxYAngleRad = maxYAngle * Mathf.Deg2Rad;

    // Generate random angle within the angle limitations
    float angleX = Random.Range(minXAngleRad, maxXAngleRad);
    float angleY = Random.Range(minYAngleRad, maxYAngleRad);

    // Generate random radius within the spawn radius limitations
    float radius = Random.Range(spawnRadiusMin, spawnRadius);

    // Calculate the direction vector
    Vector3 direction = new Vector3(Mathf.Sin(angleY) * Mathf.Cos(angleX), Mathf.Sin(angleY) * Mathf.Sin(angleX), Mathf.Cos(angleY));

    // Calculate the spawn position
    Vector3 spawnPosition = transform.position + direction * radius;

    return spawnPosition;
}

    private void OnDrawGizmos()
    {
        // Draw a sphere at the center of the spawner with a radius equal to the spawn radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);

        // Convert angle limits from degrees to radians
        float minXAngleRad = minXAngle * Mathf.Deg2Rad;
        float maxXAngleRad = maxXAngle * Mathf.Deg2Rad;
        float minYAngleRad = minYAngle * Mathf.Deg2Rad;
        float maxYAngleRad = maxYAngle * Mathf.Deg2Rad;

        // Draw lines representing the corners of the spawn area
        Vector3 startPoint = transform.position;
        Vector3 minXMinY = startPoint + Quaternion.Euler(minYAngle, minXAngle, 0) * Vector3.forward * spawnRadiusMin;
        Vector3 minXMaxY = startPoint + Quaternion.Euler(maxYAngle, minXAngle, 0) * Vector3.forward * spawnRadius;
        Vector3 maxXMinY = startPoint + Quaternion.Euler(minYAngle, maxXAngle, 0) * Vector3.forward * spawnRadiusMin;
        Vector3 maxXMaxY = startPoint + Quaternion.Euler(maxYAngle, maxXAngle, 0) * Vector3.forward * spawnRadius;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint, minXMinY);
        Gizmos.DrawLine(startPoint, minXMaxY);
        Gizmos.DrawLine(startPoint, maxXMinY);
        Gizmos.DrawLine(startPoint, maxXMaxY);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(minXMinY, minXMaxY);
        Gizmos.DrawLine(minXMaxY, maxXMaxY);
        Gizmos.DrawLine(maxXMaxY, maxXMinY);
        Gizmos.DrawLine(maxXMinY, minXMinY);
    }
}
