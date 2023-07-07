using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3Script : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRadius = 5f;
    public Collider2D saveZoneCollider;
    public float spawnInterval = 2.50f; // how often to spawn objects
    private float timeSinceLastSpawn; // keeps track of time since last spawn
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate the time that has elapsed since the start of the game
        float elapsedTime = Time.time - startTime;

        // Every 10 seconds, decrease the spawn interval by 0.1 seconds
        if (elapsedTime >= 10f && spawnInterval >= 4f)
        {
            spawnInterval -= 0.1f;
            startTime = Time.time;
        }

        // Increase the time since last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new object
        if (timeSinceLastSpawn >= spawnInterval)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Reset the time since last spawn
            timeSinceLastSpawn = 0f;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPos = Vector3.zero;
        bool foundValidSpawnPoint = false;

        // Loop until a valid spawn point is found
        while (!foundValidSpawnPoint)
        {
            // Generate a random point within the spawn radius
            randomPos = Random.insideUnitCircle * spawnRadius;

            // Check if the point is within the save zone
            if (!saveZoneCollider.bounds.Contains(randomPos))
            {
                foundValidSpawnPoint = true;
            }
        }

        return randomPos;
    }
}
