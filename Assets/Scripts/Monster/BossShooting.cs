using System.Collections;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float attackInterval = 1f;

    void Start()
    {
        InvokeRepeating("ShootBoss", 0f, attackInterval);
    }

    void ShootBoss()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Vector3 direction = (playerPosition - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}