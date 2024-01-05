using UnityEngine;

public class BackBtn : MonoBehaviour
{
    private GameObject _startUI;

    private void Start()
    {
        _startUI = transform.root.GetChild(1).gameObject;
    }

    public void Back()
    {
        _startUI.SetActive(true);
        transform.root.GetChild(2).gameObject.SetActive(false);
    }
}
