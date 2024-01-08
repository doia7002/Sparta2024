using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private TopDownCharacterController _controller;
    
    private GameObject _panelCanvas;
    private GameObject _gameUI;
    private Text _pointText;

    private float _startTime;
    private int _totalScore;
    
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
        DontDestroyOnLoad(gameObject);

        _controller = GetComponent<TopDownCharacterController>();
        level = _gameSetData.Level;

        _panelCanvas = GameObject.FindGameObjectWithTag("PanelCanvas");
        _gameUI = GameObject.FindGameObjectWithTag("GameUI");

        PausePanel = _panelCanvas.transform.GetChild(0).gameObject;
        EndPanel = _panelCanvas.transform.GetChild(1).gameObject;
        ImageObject = EndPanel.transform.GetChild(0).gameObject;
        ItemPrefab = Resources.Load<GameObject>("Items/Bomb");
        MaxScoreTxt = EndPanel.transform.GetChild(4).GetComponent<Text>();
        ThisScoreTxt = EndPanel.transform.GetChild(6).GetComponent<Text>();
        _pointText = _gameUI.transform.GetChild(1).GetComponent<Text>();

        _controller.OnPauseEvent += ActiveEndPanel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        ActiveEndPanel();
    }

    public void ActiveEndPanel()
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

    private void Pause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void NextGame()
    {
        SceneManager.LoadScene("MapScene 1");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void Retry1()
    {
        SceneManager.LoadScene("MapScene");
        Resume();
    }

    public void Retry2()
    {
        SceneManager.LoadScene("MapScene 1");
        Resume();
    }

    public void Exit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
