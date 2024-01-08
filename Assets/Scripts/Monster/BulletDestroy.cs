using UnityEngine;

public class BulletDestroy : MonoBehaviour
{    
    void Update()
    {
        if (transform.position.y < -5f || transform.position.y > 5f || transform.position.x > 5f || transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }
}
