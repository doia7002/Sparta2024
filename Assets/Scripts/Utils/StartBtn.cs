using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public void SelectPlayer()
    {
        UIManager.Instance.ChangeUI(UINumber.start, UINumber.playerSelect);
    }
}
