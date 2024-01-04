using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 targetPosition;

    void Start()
    {
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

            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 0f));

            yield return new WaitForSeconds(2f);
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}