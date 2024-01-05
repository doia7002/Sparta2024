using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject monsterPrefab2;
    public float spawnInterval = 3f; 

    void Start()
    {
        InvokeRepeating("SpawnMonster", 0f, spawnInterval);
    }

    void SpawnMonster()
    {
        float randomX1 = Random.Range(0f, Screen.width);
        float positionY = Screen.height;
        Vector2 spawnPosition1 = Camera.main.ScreenToWorldPoint(new Vector2(randomX1, positionY));
        Instantiate(monsterPrefab, spawnPosition1, Quaternion.identity);

        float randomX2 = Random.Range(0f, Screen.width);
        Vector2 spawnPosition2 = Camera.main.ScreenToWorldPoint(new Vector2(randomX2, positionY));
        Instantiate(monsterPrefab2, spawnPosition2, Quaternion.identity);
    }
}
