using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public List<Transform> spawnPoints;
    public float spawnInterval = 5f;
    public int maxPickups = 10;

    private List<GameObject> spawnedPickups = new List<GameObject>();
    private float timeSinceLastSpawn = 0f;

    private GameManager gameManager;

    private void Start()
    {
        timeSinceLastSpawn = spawnInterval;
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (spawnedPickups.Count >= maxPickups)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPickup();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnPickup()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];
        GameObject newPickup = Instantiate(pickupPrefab, selectedSpawnPoint.position, Quaternion.identity);
        spawnedPickups.Add(newPickup);
    }
}