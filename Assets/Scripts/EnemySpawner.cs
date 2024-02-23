using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float enemySpawnDelay;
    [SerializeField] private float enemySpawnMinInterval;
    [SerializeField] private float enemySpawnMaxInterval;

    private void Start()
    {
        InvokeRepeating("EnemySpawn", enemySpawnDelay, Random.Range(enemySpawnMinInterval, enemySpawnMaxInterval));
    }

    private void EnemySpawn()
    {
        int randomSpawnPoints = Random.Range(0, spawnPoints.Length);
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoints].position, transform.rotation);
    }
}
