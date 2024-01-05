using UnityEngine;

public enum UINumber
{
    backImage,
    start,
    playerSelect,
    difficuly
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private GameObject[] _uIs = new GameObject[4];

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
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _uIs[0] = transform.GetChild((int)UINumber.backImage).gameObject;
        _uIs[1] = transform.GetChild((int)UINumber.start).gameObject;
        _uIs[2] = transform.GetChild((int)UINumber.playerSelect).gameObject;
        _uIs[3] = transform.GetChild((int)UINumber.difficuly).gameObject;
    }

    public void ChangeUI(UINumber currentUI, UINumber nextUI)
    {
        _uIs[(int)nextUI].SetActive(true);
        _uIs[(int)currentUI].SetActive(false);
    }
}
