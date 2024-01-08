using UnityEngine;
using TMPro;

public class BombManager : Singleton<BombManager>
{
    //public static BombManager Instance;
    
    private GameObject[] _bombs = new GameObject[4];
    private int _bombsCount;
    
    [SerializeField] private GameObject _bombPrefab;
    
    // field for unit test
    private int _point;
    public TMP_Text PointText;
    // end of field for unit test
    
    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(Instance);
    //    }
    //}
    
    // Start is called before the first frame update
    private void Start()
    {
        _bombsCount = 3;
        
        for (int i = 0; i < _bombs.Length; i++)
        {
            _bombs[i] = transform.GetChild(i).gameObject;
        }
    }
    
    public void UseBomb()
    {
        if(_bombsCount > 0)
        {
            _bombs[_bombsCount - 1].SetActive(false);
            _bombsCount--;
        }
        else
        {
            return;
        }
    }
    
    public void GetBomb()
    {
        if (_bombsCount < 4)
        {
            _bombs[_bombsCount - 1].SetActive(true);
            _bombsCount++;
            Debug.Log($"{_bombsCount}");
        }
        else
        {
            BombToPoint();
            Debug.Log($"{_bombsCount}");
        }
    }
    
    private void BombToPoint()
    {
        GameManager.Instance.AddScore(50);
    }

    public void BombInit()
    {
        _bombsCount = 3;
    }
    
    // code for unit test
    public void GetPoint(int point)
    {
        _point += point;
    }
    
    public void UpdatePoint()
    {
        PointText.text = _point.ToString();
    }
    // end of unit test
}
