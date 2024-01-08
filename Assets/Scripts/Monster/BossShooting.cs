using System.Collections;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public MonsterBulletData monsterBulletData;
    public Level level;
    public GameObject bulletPrefab;

    //public ObjectManager objectManager;

    public ObjectManager objectManager;

    public float attackInterval = 1f;
    public int bulletCount = 20;
    public float rotationSpeed = 5f;
    public float waveFrequency = 2f;
    public float amplitude = 3f;
    
    void Awake()
    {
        level = GameManager.Instance.level;
        StartCoroutine(AttackPatternRoutine());
    }

    public IEnumerator AttackPatternRoutine()
    {
        while (true)
        {
            // Circular Bullets
            ShootCircularBullets();
            yield return new WaitForSeconds(2f);

            // Player Targeted Bullets
            ShootBoss();
            yield return new WaitForSeconds(attackInterval);

            // Bullet Wave Pattern
            ShootBulletWave();
            yield return new WaitForSeconds(3f);
        }
    }

    [SerializeField] public void ShootCircularBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.up;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * (monsterBulletData.speed + (int)level);
        }
    }

    
    [SerializeField] public void ShootBoss()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Vector3 direction = (playerPosition - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * (monsterBulletData.speed + (int)level);
        }
    }

    [SerializeField] public void ShootBulletWave()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            float yOffset = Mathf.Sin(angle * waveFrequency) * amplitude;
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.up;
            Vector3 spawnPosition = transform.position + new Vector3(0f, yOffset, 0f);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * (monsterBulletData.speed + (int)level);
        }
    }

    
}
