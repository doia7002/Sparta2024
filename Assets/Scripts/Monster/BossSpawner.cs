using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossMonsterPrefab;
    private float bossSpawnDelay = 10f;

    void Start()
    {   
        Invoke("SpawnBossMonster", bossSpawnDelay);
    }
    void SpawnBossMonster()
    {
        float randomX = Random.Range(0f, Screen.width);
        float positionY = Screen.height;

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector2(randomX, positionY));

        Instantiate(bossMonsterPrefab, spawnPosition, Quaternion.identity);
    }
}
