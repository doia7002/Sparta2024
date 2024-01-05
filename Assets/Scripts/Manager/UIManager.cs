using UnityEngine;

public enum UINumber
{
    backImage,
    start,
    playerSelect,
    level
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private GameObject[] _UIs = new GameObject[4];

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _UIs[0] = transform.GetChild((int)UINumber.backImage).gameObject;
        _UIs[1] = transform.GetChild((int)UINumber.start).gameObject;
        _UIs[2] = transform.GetChild((int)UINumber.playerSelect).gameObject;
        _UIs[3] = transform.GetChild((int)UINumber.level).gameObject;
    }

    public void ChangeUI(UINumber currentUI, UINumber nextUI)
    {
        _UIs[(int)nextUI].SetActive(true);
        _UIs[(int)currentUI].SetActive(false);
    }

    public void ChangeUI(GameObject gameObject, UINumber nextUI)
    {
        _UIs[(int)nextUI].SetActive(true);
        gameObject.SetActive(false);
    }
}
