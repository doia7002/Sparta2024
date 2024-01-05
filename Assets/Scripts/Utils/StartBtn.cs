using UnityEngine;

public class StartBtn : MonoBehaviour
{
    private GameObject _selectUI;

    // Start is called before the first frame update
    private void Start()
    {
        _selectUI = transform.root.GetChild(2).gameObject;
    }

    public void SelectPlayer()
    {
        _selectUI.SetActive(true);
        transform.root.GetChild(1).gameObject.SetActive(false);
    }
}
