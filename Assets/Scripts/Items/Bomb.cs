using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float speed;
    private Vector2 direction;

    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        
        float randomX = Random.Range(-10, 10);
        float randomY = Random.Range(-10, 10);
        direction = new Vector2(randomX, randomY);
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
        // Rigidbody2D가 없다면 추가
        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        }
        
        _rigidbody.velocity = direction.normalized * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BombManager.Instance.GetBomb();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "HorizontalWall")
        {
            direction.y = direction.y * -1;
            _rigidbody.velocity = direction.normalized * speed;
        }
        else if (collision.gameObject.tag == "VerticalWall")
        {
            direction.x = direction.x * -1;
            _rigidbody.velocity = direction.normalized * speed;
        }
    }
}
