using System.Collections;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public MonsterBulletData monsterBulletData;
    public Level level;
    public GameObject bulletPrefab;

    //public ObjectManager objectManager;

    public GameObject bulletPrefab2;
    public ObjectManager objectManager;
    public float bulletSpeed = 10f;

    public float attackInterval = 1f;
    public int bulletCount = 20;
    public float rotationSpeed = 5f;
    public float waveFrequency = 2f;
    public float amplitude = 3f;
    
    void Start()
    {
        level = GameManager.Instance.level;
        StartCoroutine(AttackPatternRoutine());
    }

    IEnumerator AttackPatternRoutine()
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

            yield return StartCoroutine(ShootBounceBullet());
            ShootBounceBullet();
            yield return new WaitForSeconds(5f);


        }
    }

    void ShootCircularBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.up;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * (monsterBulletData.speed + (int)level);
        }
    }

    void ShootBoss()
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

    void ShootBulletWave()
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

    IEnumerator ShootBounceBullet()
    {
        float[] bulletAngles = { 225f, 250f, 275f, 300f, 325f };

        foreach (float angle in bulletAngles)
        {
            float bulletAngleInRadians = angle * Mathf.Deg2Rad;
            GameObject newBullet = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(Mathf.Cos(bulletAngleInRadians), Mathf.Sin(bulletAngleInRadians)) * bulletSpeed;

            StartCoroutine(DestroyBulletAfterDelay(newBullet));

            yield return new WaitForSeconds(0.5f);

        }
    }
    IEnumerator DestroyBulletAfterDelay(GameObject newBullet)
    {
        yield return new WaitForSeconds(5f);
        if (newBullet != null)
        {
            Destroy(newBullet);
        }
    }
}
