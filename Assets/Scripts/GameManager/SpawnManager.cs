using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnEffectPrefab;
    public Transform[] spawnPoints;
    public float initialSpawnDelay = 0f; // Set to 0 to spawn the first enemy immediately
    public float spawnDelay = 2f;

    private List<int> usedSpawnIndices = new List<int>();

    private void Start()
    {
        // Spawn the first enemy immediately
        SpawnEnemy();

        // Start spawning enemies with a delay
        InvokeRepeating("SpawnEnemy", initialSpawnDelay + spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (usedSpawnIndices.Count == spawnPoints.Length)
            usedSpawnIndices.Clear();

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, spawnPoints.Length);
        } while (usedSpawnIndices.Contains(randomIndex));

        usedSpawnIndices.Add(randomIndex);
        Transform spawnPoint = spawnPoints[randomIndex];

        if (spawnEffectPrefab != null)
        {
            Instantiate(spawnEffectPrefab, spawnPoint.position, Quaternion.identity);
        }

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
