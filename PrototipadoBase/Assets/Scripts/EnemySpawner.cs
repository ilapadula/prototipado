using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBehaviour enemyPrefab;
    public HeroBehaviour hero;
    public int initialSpawn;
    public float spawnInterval;
    public int minSpawn;
    public int maxSpawn;

    private float timer;


    void Start()
    {
        SpawnEnemiesAtRandomPosition(initialSpawn);
    }

    private void SpawnEnemiesAtRandomPosition(int spawnCount)
    {
        if (hero == null)
            return;

        for (int i = 0; i < spawnCount; i++)
        {
           // var randomPosition = new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-20, 20));
            var randomPosition = new Vector3(UnityEngine.Random.Range(-17, 16), 0, UnityEngine.Random.Range(-4, 28));
            var enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemy.hero = hero;
            enemy.enemySpeed *= UnityEngine.Random.Range(0.7f, 1.3f);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            var spawned = Random.Range(minSpawn, maxSpawn);
            SpawnEnemiesAtRandomPosition(spawned);
            timer = 0;
        }
    }
}
