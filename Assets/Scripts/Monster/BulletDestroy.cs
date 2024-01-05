using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{    
    void Update()
    {
                          
      if (transform.position.y < -10f)
       {
         Destroy(gameObject);
       }
        
    }
}
