using UnityEngine;

public class BombManager : Singleton<BombManager>
{
    private GameObject[] _bombs = new GameObject[4];
    private int _bombsCount;

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
            _bombsCount++;
            _bombs[_bombsCount - 1].SetActive(true);
        }
        else
        {
            BombToPoint();
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
}
