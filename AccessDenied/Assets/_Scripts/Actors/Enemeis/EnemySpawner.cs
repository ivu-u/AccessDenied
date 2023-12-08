using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float minSpawnTime = 3f; // Minimum time between spawns
    public float maxSpawnTime = 10f; // Maximum time between spawns
    public float spawnRadius = 5f; // Radius to check for existing enemies
    private float spawnTimer; // Timer for tracking spawn time

    void Start() {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime); // Set an initial random spawn time
    }

    void Update() {
        spawnTimer -= Time.deltaTime; // Count down the spawn timer

        if (spawnTimer <= 0) {
            SpawnEnemyIfNoneNearby();
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime); // Reset spawn timer
        }
    }

    void SpawnEnemyIfNoneNearby() {
        bool isEnemyNearby = Physics.CheckSphere(transform.position, spawnRadius, LayerMask.GetMask("Enemy"));

        if (!isEnemyNearby) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
