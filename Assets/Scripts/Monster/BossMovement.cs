using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 tagetPosition;

    void Start()
    {
        StartCoroutine(MoveBoss());
    }

    IEnumerator MoveBoss()
    {
        while (true)
        {
            float bossX = (float)Screen.width / 2f;
            float bossY = (float)(Screen.height * 0.8f);
            tagetPosition = Camera.main.ScreenToWorldPoint(new Vector2(bossX,bossY));

            transform.position = Vector2.Lerp(transform.position,tagetPosition,moveSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0.1f);
        }
    }
}