using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    public GameSetSO GameSetData;

    private int currentHp;
    
    private void Start()
    {
        currentHp = monsterData.maxhp;
    }

    private void OnTriggerEnter2D(Collider2D collider )
    {
        // ���Ϳ� �Ѿ��� �浹������ �ڵ�
        if (collider.gameObject.tag == "PlayerBullet") //ĳ���� �Ѿ��� �±�ó���ϸ��
        {
            
            Destroy(collider.gameObject);
            TakeDamage(GameSetData.Damage); // 10�� ĳ����SO ���ݷ� �ֱ�
        }
    }

    void OnDestroy()
    {
        if (gameObject.CompareTag("Boss"))
        {
            GameManager.Instance.StageEnd(DeadCase.bossDead);
            GameManager.Instance.AddScore(50);
        }

        if (gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(10);
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
        float dropChance = 1f;
        float randomValue = Random.value;

        if (randomValue <= dropChance)
        {
            GameManager.Instance.SpawnItem(transform.position);
        }

        Destroy(gameObject);
    }
}
