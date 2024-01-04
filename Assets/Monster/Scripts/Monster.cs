using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public MonsterData monsterData;

    private int currentHp;
    
    private void Update()
    {
       
    }

    private void Start()
    {
        currentHp = monsterData.maxhp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 몬스터와 총알이 충돌했을때 코드
        if (collision.gameObject.tag == "bullet") //캐릭터 총알을 태그처리하면됨
        {
            Destroy(collision.gameObject);
            TakeDamage(10); // 10이 캐릭터 공격력이라 생각
        }
    }

        public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if(currentHp < 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }


   
}
