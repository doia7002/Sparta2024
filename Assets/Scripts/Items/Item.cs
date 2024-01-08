using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float fallSpeed = 1.0f; 
    public float lifeTime = 5.0f; 

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime); 

        
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
