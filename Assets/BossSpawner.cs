using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonsterSpawner
{
    public GameObject bossMonsterPrefab;
    public float bossSpawnDelay = 100f;

    void Start()
    {   
        Invoke("StopSpawningBoss", bossSpawnDelay);
    }
   
    void StopSpawningBoss()
    {
        // InvokeRepeating¿ª ∏ÿ√„
        CancelInvoke("SpawnMonster");

        SpawnBossMonster();
    }

    void SpawnBossMonster()
    {
        float randomX = Random.Range(0f, Screen.width);

        float screenHeight = Camera.main.orthographicSize * 2f;
        float randomY = screenHeight;

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 0f));

        Instantiate(bossMonsterPrefab, spawnPosition, Quaternion.identity);
    }
}
