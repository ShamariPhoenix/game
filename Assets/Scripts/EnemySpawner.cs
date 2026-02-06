using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public LevelWaveData levelWaveData;
    public Transform enemyParentTransform;
    public float enemySpawnDistance = 1;
    public float spawnDistanceJitter = 1;
    private float timer = 0;
    private int currentWave = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        currentWave = 0;
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > levelWaveData.timeBetweenWaves) {
            timer = 0;
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        // If there are no more waves, return
        if(currentWave >= levelWaveData.waveData.Count) {
            return;
        }

        // get the current wave
        WaveData waveData = levelWaveData.waveData[currentWave];

        foreach(EnemyInWaveData enemyInWaveData in waveData.enemyData)
        {
            GameObject enemyPrefab = enemyInWaveData.enemyPrefab;
            int count = enemyInWaveData.count;

            for(int i = 0; i < count; i++)
            {
                var enemy = Instantiate(enemyPrefab, enemyParentTransform);
                enemy.transform.position = GetRandomLocation();
            }
        }


        currentWave++;
    }

    private Vector3 GetRandomLocation() {
        var radians = UnityEngine.Random.value * 2 * Mathf.PI;
        var spawnDistance = (Random.value - 0.5f) * 2 * spawnDistanceJitter + enemySpawnDistance;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0) * spawnDistance;
    }
}
