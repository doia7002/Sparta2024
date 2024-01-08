using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum Level
{
    basic = 1,
    standard,
    challenge
}

public enum DeadCase
{
    playerDead = 0,
    bossDead
}

public class GameManager : MonoBehaviour
{
    public Level level;
    public static GameManager Instance;

    private GameObject PausePanel;
    private GameObject EndPanel;
    private GameObject ImageObject;
    private GameObject ItemPrefab;
    private Text MaxScoreTxt;
    private Text ThisScoreTxt;
    [SerializeField] private GameSetSO _gameSetData;
    
    private GameObject _panelCanvas;
    private GameObject _gameUI;
    private TMP_Text _pointText;
    private int _totalScore;
    
    private void GameInit()
    {
        level = _gameSetData.Level;
        _totalScore = _gameSetData.CurScore;

        _panelCanvas = GameObject.FindGameObjectWithTag("PanelCanvas");
        Debug.Log($"{_panelCanvas.gameObject.name}");
        _gameUI = GameObject.FindGameObjectWithTag("GameUI");
        Debug.Log($"{_gameUI.gameObject.name}");

        PausePanel = _panelCanvas.transform.GetChild(0).gameObject;
        EndPanel = _panelCanvas.transform.GetChild(1).gameObject;
        ImageObject = EndPanel.transform.GetChild(0).gameObject;
        ItemPrefab = Resources.Load<GameObject>("Items/Bomb");
        MaxScoreTxt = EndPanel.transform.GetChild(4).GetComponent<Text>();
        ThisScoreTxt = EndPanel.transform.GetChild(6).GetComponent<Text>();
        _pointText = _gameUI.transform.GetChild(1).GetComponent<TMP_Text>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);

        GameInit();
        Resume();
    }

    private void ActiveEndPanel()
    {
        Time.timeScale = 0f;
        EndPanel.SetActive(true);
    }

    public void StageEnd(DeadCase deadvalue)
    {
        if (deadvalue == DeadCase.bossDead) // player dead
        {
            ActiveEndPanel();
            ImageObject.SetActive(true);
        }

        else if (deadvalue == DeadCase.playerDead) // player dead
        {
            ActiveEndPanel();
            ImageObject.SetActive(false);
        }

        if (PlayerPrefs.HasKey("bestscore") == false)
        {
            PlayerPrefs.SetFloat("bestscore", _totalScore);
        }
        else
        {
            if (_totalScore > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", _totalScore);
            }
        }

        ThisScoreTxt.text = _totalScore.ToString();
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        MaxScoreTxt.text = maxScore.ToString("N2");
    }

    public void AddScore(int Score)
    {
        if (ThisScoreTxt != null)
        {
            _gameSetData.CurScore += Score;
            _totalScore += Score;
            ThisScoreTxt.text = _totalScore.ToString();
            _pointText.text = _totalScore.ToString();
        }
    }

    public void SpawnItem(Vector3 position)
    {
        if (ItemPrefab != null)
        {
            GameObject newItem = Instantiate(ItemPrefab, position, Quaternion.identity);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void NextGame()
    {
        Debug.Log("NextGame");
        SceneManager.LoadScene("Stage2");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void Retry1()
    {
        _gameSetData.CurScore = 0;
        BombManager.Instance.BombInit();
        SceneManager.LoadScene("Stage1");
    }

    public void Retry2()
    {
        _gameSetData.CurScore = 0;
        BombManager.Instance.BombInit();
        SceneManager.LoadScene("Stage2");
    }

    public void Exit()
    {
        _gameSetData.CurScore = 0;
        SceneManager.LoadScene("StartScene");
    }
}
