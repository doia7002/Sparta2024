using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameSetSO _gameSetData;
    public GameObject PlayerActive;

    public void Awake()
    {
        SpriteRenderer image = transform.GetChild(0).GetComponent<SpriteRenderer>();
        image.sprite = _gameSetData.SpriteImage;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Bomb")
        {
            return;
        }
        else if (collider.isTrigger)
        {
            PlayerActive.SetActive(false);
            GameManager.Instance.StageEnd(DeadCase.playerDead);
        }
    }
}
