using Unity.VisualScripting;
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
    public GameObject PausePanel;
    public GameObject EndPanel;    
    public GameObject ImageObject;
    public GameObject ItemPrefab;
    public Text ThisScoreTxt;
    public Text MaxScoreTxt;

    private TopDownCharacterController _controller;
    [SerializeField] private GameSetSO _gameSetData;
    
    float StartTime;
    int TotalScore;
    
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

        level = _gameSetData.Level;
        GameObject Boss = GameObject.FindGameObjectWithTag("Boss");
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        _controller.OnPauseEvent += ActiveEndPanel;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            
        }
        ActiveEndPanel();
    }
    bool HasTenSecondsPassed()
    {
        return (Time.time - StartTime) >= 11f; // 게임 시작 후 10초가 지났는지 확인
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
            PlayerPrefs.SetFloat("bestscore", TotalScore);
        }
        else
        {
            if (TotalScore > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", TotalScore);
            }
        }

        ThisScoreTxt.text = TotalScore.ToString();
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        MaxScoreTxt.text = maxScore.ToString("N2");
    }


    public void AddScore(int Score)
    {
        if (ThisScoreTxt != null)
        {
            TotalScore += Score;
            ThisScoreTxt.text = TotalScore.ToString();
        }
    }

    public void SpawnItem(Vector3 position)
    {
        if (ItemPrefab != null)
        {            
                       
            GameObject newItem = Instantiate(ItemPrefab, position, Quaternion.identity);
            
        }
    }
    

    void Pause()
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

    public void ChooseDifficulty()
    {
        if(level == Level.basic)
        {
            //basic씬 선택해서 로드
        }
        else if(level == Level.standard)
        {
            // normal씬 선택해서 로드
        }
        else if (level == Level.challenge)
        {
            //hard씬 선택해서 로드
        }
    }
}
