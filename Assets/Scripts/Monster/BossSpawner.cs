using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossMonsterPrefab;
    public float bossSpawnDelay = 100f;

    void Start()
    {   
        Invoke("StopSpawningBoss", bossSpawnDelay);
    }
   
    void StopSpawningBoss()
    {
        CancelInvoke("SpawnMonster");

        SpawnBossMonster();
    }

    void SpawnBossMonster()
    {
        float randomX = Random.Range(0f, Screen.width);

        float positionY = Screen.height;
        

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector2(randomX, positionY));

        Instantiate(bossMonsterPrefab, spawnPosition, Quaternion.identity);
    }
}
