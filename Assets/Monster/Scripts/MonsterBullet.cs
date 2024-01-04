using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MonsterBullet : MonoBehaviour
{

    public MonsterBulletData monsterBulletData;
    public MonsterBulletType monsterBulletType;
    public GameObject NormalBullet;
    public GameObject SpreadBullet;
    
    

    private void Start()
    {
        
    }

    void SpawnBullets()
    {
        for (int i = 0; i < monsterBulletData.BulletNumber; i++)
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        if (monsterBulletData.type == MonsterBulletType.Normal)
        {
            GameObject bullet = Instantiate(NormalBullet, new Vector3(0f, 0f, 0f), Quaternion.identity);
            
            
        }
        else if(monsterBulletData.type == MonsterBulletType.Spread)
        {
            GameObject bullet = Instantiate(SpreadBullet, new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 몬스터 총알과 캐릭터가 충돌했을때 코드
        if (collision.gameObject.tag == "Player") //캐릭터에 플레이어 태그넣기
        {
            Destroy(collision.gameObject);            
        }
    }










}
    


