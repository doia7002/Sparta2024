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
        // ���Ϳ� �Ѿ��� �浹������ �ڵ�
        if (collision.gameObject.tag == "bullet") //ĳ���� �Ѿ��� �±�ó���ϸ��
        {
            Destroy(collision.gameObject);
            TakeDamage(10); // 10�� ĳ���� ���ݷ��̶� ����
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
