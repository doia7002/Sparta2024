using UnityEngine;

public class Monster1Movement : MonoBehaviour
{
    public MonsterData monsterData;
    public Level level;

    void Update()
    {
        transform.Translate(Vector2.down * (monsterData.speed + 0.5f * (int)level) * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            gameObject.SetActive(false);
        }
    }
}