using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;   // The pickup prefab to be spawned
    public List<Transform> spawnPoints; // List of spawn points for pickups
    public float spawnInterval = 5f;   // Time interval between spawning pickups
    public int maxPickups = 10;        // Maximum number of pickups to spawn

    private List<GameObject> spawnedPickups = new List<GameObject>();
    private float timeSinceLastSpawn = 0f;

    private void Start()
    {
        // Initialize the timer to allow immediate spawning
        timeSinceLastSpawn = spawnInterval;
    }

    private void Update()
    {
        // Check if the maximum number of pickups has been reached
        if (spawnedPickups.Count >= maxPickups)
        {
            return; // Stop spawning if the maximum limit is reached
        }

        // Update the timer
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new pickup
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPickup();
            timeSinceLastSpawn = 0f; // Reset the timer
        }
    }

    private void SpawnPickup()
    {
        // Randomly select a spawn point
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        // Instantiate a new pickup at the selected spawn point
        GameObject newPickup = Instantiate(pickupPrefab, selectedSpawnPoint.position, Quaternion.identity);

        // Add the pickup to the list of spawned pickups
        spawnedPickups.Add(newPickup);
    }
}