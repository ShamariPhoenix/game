using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelWaveData", menuName = "ScriptableObjects/LevelWaveData", order = 1)]
public class LevelWaveData : ScriptableObject
{
    public List<WaveData> waveData;
    public float timeBetweenWaves;
}

[Serializable]
public struct WaveData
{
    public List<EnemyInWaveData> enemyData;
}

[Serializable]
public struct EnemyInWaveData
{
    public GameObject enemyPrefab;
    public int count;
}