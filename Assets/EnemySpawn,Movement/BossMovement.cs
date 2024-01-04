using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 tagetPosition;
    void Start()
    {
        StartCoroutine(MoveDown());
    }

    IEnumerator MoveDown()
    {
        while (true)
        {
            float bossX = Screen.width / 2;
            float bossY = (float)(Screen.height * 0.8);
            tagetPosition = Camera.main.ScreenToWorldPoint(new Vector3(bossX,bossY));
            
            transform.Translate(tagetPosition * moveSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0.1f);
        }
    }
}