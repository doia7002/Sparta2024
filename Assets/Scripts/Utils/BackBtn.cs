using UnityEngine;

public class BackToStartBtn : MonoBehaviour
{
    public void Back()
    {
        GameObject currentUI = transform.parent.gameObject;

        UIManager.Instance.ChangeUI(currentUI, UINumber.start);
    }
}
