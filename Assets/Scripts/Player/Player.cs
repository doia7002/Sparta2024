using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerActive;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger)
        {
            PlayerActive.SetActive(false);
            GameManager.Instance.StageEnd(DeadCase.playerDead);
        }
    }
}
