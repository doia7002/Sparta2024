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
        float y = Camera.main.orthographicSize * 2f;
        Vector3 spawnPosition1 = Camera.main.ScreenToWorldPoint(new Vector3(randomX1, y, 0f));
        Instantiate(monsterPrefab, spawnPosition1, Quaternion.identity);

        float randomX2 = Random.Range(0f, Screen.width);
        Vector3 spawnPosition2 = Camera.main.ScreenToWorldPoint(new Vector3(randomX2, y, 0f));
        Instantiate(monsterPrefab2, spawnPosition2, Quaternion.identity);
    }
}
