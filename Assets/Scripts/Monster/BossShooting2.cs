using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting2 : BossShooting
{
    public GameObject bulletPrefab2;
    void Start()
    {
        level = GameManager.Instance.level;
        StartCoroutine(AttackPatternRoutine2());
    }
    IEnumerator AttackPatternRoutine2()
    {
        while(true)
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
            yield return new WaitForSeconds(5f);
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
            bulletRigidbody.velocity = new Vector2(Mathf.Cos(bulletAngleInRadians), Mathf.Sin(bulletAngleInRadians)) * (monsterBulletData.speed + (int)level);

            StartCoroutine(DestroyBulletAfterDelay(newBullet));

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator DestroyBulletAfterDelay(GameObject newBullet)
    {
        yield return new WaitForSeconds(10f);
        if (newBullet != null)
        {
            Destroy(newBullet);
        }
    }
}