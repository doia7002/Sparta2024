using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MonsterBullet : MonoBehaviour
{
    public GameObject RangeMonster;
    public GameObject Player;
    public GameObject Bullet;
    public MonsterBulletData monsterBulletData;

    private Transform _monsterTransform;
    private Transform _playerTransform;

    public Level level;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        level = GameManager.Instance.level;

        int startDelay = 5 - (int)level;
        int endDelay = 3 - (int)level;

        _monsterTransform = RangeMonster.GetComponent<Transform>();
        _playerTransform = Player.GetComponent<Transform>();
        InvokeRepeating("ShootBullet", startDelay, endDelay);
    }

   
   
   void ShootBullet()
    {
        float x = _monsterTransform.position.x;
        float y = _monsterTransform.position.y - 2.0f;
        
        Vector3 direction = (_playerTransform.position - _monsterTransform.position).normalized;
        float speed = monsterBulletData.speed + (int)level * 0.5f;

        GameObject bullet = Instantiate(Bullet, _monsterTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }


}
    


