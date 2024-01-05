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
        
    
    private void Start()
    {
      GameManager.Difficulty difficulty = GameManager.Instance.difficulty;

        int startDelay = 5 - (int)difficulty;
        int endDelay = 3 - (int)difficulty;

        _monsterTransform = RangeMonster.GetComponent<Transform>();
        _playerTransform = Player.GetComponent<Transform>();
        InvokeRepeating("ShootBullet", startDelay, endDelay);
    }

    void makeBullet()
    {
        float x = _monsterTransform.position.x;
        float y = _monsterTransform.position.y - 2.0f;
        Instantiate(Bullet, new Vector3(x, y, 0), Quaternion.identity);
    }

   void BulletVector()
    {
        Vector3 direction = (_playerTransform.position - _monsterTransform.position).normalized;
        float speed = monsterBulletData.speed;

        GameObject bullet = Instantiate(Bullet, _monsterTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void ShootBullet()
    {
        makeBullet();
        BulletVector();
    }

 



}
    


