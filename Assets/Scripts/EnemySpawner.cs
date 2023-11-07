using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab with the 'EnemyMovement' script.
    public int numberOfGroups = 5; // Number of enemy groups to spawn.
    public float groupSpacing = 5f; // Spacing between enemy groups.
    public float groupSpawnInterval = 10f; // Time between spawning enemy groups.

    private Vector3 spawnPosition;
    private int groupsSpawned = 0;

    void Start()
    {
        spawnPosition = transform.position;

        // Start spawning enemy groups.
        InvokeRepeating("SpawnEnemyGroup", 5f, groupSpawnInterval);
    }

    void SpawnEnemyGroup()
    {
        if (groupsSpawned < numberOfGroups)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            groupsSpawned++;

            // Update the spawn position for the next group.
            spawnPosition += Vector3.up * groupSpacing;
        }
        else
        {
            // Stop spawning when the desired number of groups is reached.
            CancelInvoke("SpawnEnemyGroup");
        }
    }
}
