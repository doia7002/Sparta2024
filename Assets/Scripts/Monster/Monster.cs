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
        // 몬스터와 총알이 충돌했을때 코드
        if (collider.gameObject.tag == "PlayerBullet") //캐릭터 총알을 태그처리하면됨
        {
            
            Destroy(collider.gameObject);
            TakeDamage(GameSetData.Damage); // 10이 캐릭터SO 공격력 넣기
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
        if (gameObject.CompareTag("Boss"))
        {
            GameManager.Instance.StageEnd(DeadCase.bossDead);
            GameManager.Instance.AddScore(50 * (int)GameSetData.Level);
        }

        if (gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(10 * (int)GameSetData.Level);
        }

        float dropChance = 1f;
        float randomValue = Random.value;

        if (randomValue <= dropChance)
        {
            GameManager.Instance.SpawnItem(transform.position);
        }

        Destroy(gameObject);
    }
}
