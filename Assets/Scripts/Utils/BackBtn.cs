using UnityEngine;

public class BackToStartBtn : MonoBehaviour
{
    public void Back()
    {
        UIManager.Instance.ChangeUI(UINumber.playerSelect, UINumber.start);
    }
}
