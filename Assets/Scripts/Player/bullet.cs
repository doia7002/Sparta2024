using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameSetSO GameSetData;
    public GameObject BulletPrefab;
    
    void Update()
    {
        transform.position += new Vector3(0.0f, 0.3f, 0.0f);
        if (transform.position.y > 10.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            Debug.Log("Hit");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.gameObject.transform.forward * GameSetData.Damage);
            Destroy(BulletPrefab);
        }
        else
        {
            return;
        }
    }
}
