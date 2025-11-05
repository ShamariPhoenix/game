using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyParentTransform;
    public float enemiesPerSecond = 1;
    public int maxEnemiesToSpawn;
    public float enemySpawnDistance = 1;

    private int numEnemiesSpawned = 0;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numEnemiesSpawned >= maxEnemiesToSpawn) {
            return;
        }

        timer += Time.deltaTime;

        if(timer > 1 / enemiesPerSecond) {
            timer = 0;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        var enemy = Instantiate(enemyPrefab, enemyParentTransform);
        enemy.transform.position = GetRandomLocation();
    }

    private Vector3 GetRandomLocation() {
        var radians = UnityEngine.Random.value * 2 * Mathf.PI;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0) * enemySpawnDistance;
    }
}
