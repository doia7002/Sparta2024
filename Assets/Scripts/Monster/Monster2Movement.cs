using System.Collections;
using UnityEngine;

public class Monster2Movement : MonoBehaviour
{
    public MonsterData monsterData;
    private Vector2 targetPosition;

    public Level level;

    void Start()
    {
        level = GameManager.Instance.level;
        StartCoroutine(MoveRandomly());
    }

    void Update()
    {
        MoveToTarget();
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            float randomX = Random.Range(0f, Screen.width);
            float randomY = Random.Range(Screen.height * 0.7f, Screen.height);

            targetPosition = Camera.main.ScreenToWorldPoint(new Vector2(randomX, randomY));

            yield return new WaitForSeconds(2f);
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector2.Lerp(transform.position, targetPosition, (monsterData.speed + 0.5f * (int)level) * Time.deltaTime);
    }
}