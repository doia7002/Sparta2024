using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    private bool _isCollided = false;
    
    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        
        float randomX = Random.Range(-100, 100);
        float randomY = Random.Range(-100, 100);
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
        if (!_isCollided)
        {
            if (collision.gameObject.tag == "Player")
            {
                //transform.gameObject.SetActive(false);
                BombManager.Instance.GetBomb();
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "HorizontalWall")
            {
                Debug.Log("horizon Collision");

                direction.y = direction.y * -1;
                _rigidbody.velocity = direction.normalized * speed;
            }
            else if (collision.gameObject.tag == "VerticalWall")
            {
                Debug.Log("vertical Collision");

                direction.x = direction.x * -1;
                _rigidbody.velocity = direction.normalized * speed * (-1);
            }

            _isCollided = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        _isCollided = false;
    }
}
