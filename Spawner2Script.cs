using UnityEngine;

public class Spawner2Script : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRadius = 5f;
    public Collider2D saveZoneCollider;
    public float spawnInterval = 2.50f;
    private float timeSinceLastSpawn;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= 10f && spawnInterval >= 2f)
        {
            spawnInterval -= 0.1f;
            startTime = Time.time;
        }

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            timeSinceLastSpawn = 0f;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPos = Vector3.zero;
        bool foundValidSpawnPoint = false;

        while (!foundValidSpawnPoint)
        {
            randomPos = Random.insideUnitCircle * spawnRadius;
            if (!saveZoneCollider.bounds.Contains(randomPos))
            {
                foundValidSpawnPoint = true;
            }
        }

        return randomPos;
    }
}