using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Difficulty difficulty;
    public float ItemDropChance = 0.1f;
    public float ItemMoveSpeed = 1f; 
    public float ItemDuration = 5f; 
    public static GameManager Instance;
    public GameObject ItemPrefab;
    public GameObject PausePanel;
    public GameObject EndPanel;    
    public GameObject ImageObject;
    public Text ThisScoreTxt;
    public Text MaxScoreTxt;
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

        difficulty = Difficulty.basic;
    }

    void Start()
    {
        //Transform parentTransform = GameObject.Find("Canvas").transform;
        //Transform childTransform = parentTransform.Find("�ڽİ�ü�̸�");
        GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();            
        }
    }

    public void CreateItem(Vector3 position)
    {
        
        if (Random.value <= ItemDropChance && ItemPrefab != null)
        {
            GameObject newItem = Instantiate(ItemPrefab, position, Quaternion.identity);

            
            StartCoroutine(MoveItem(newItem));

            
            Destroy(newItem, ItemDuration);
        }
    }
    IEnumerator MoveItem(GameObject item)
    {
        while (item != null)
        {
            // �������� �Ʒ��� �̵�
            item.transform.Translate(Vector3.down * ItemMoveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void ActiveEndPanel()
    {
        Time.timeScale = 0f;
        EndPanel.SetActive(true);

        if (GameObject.FindGameObjectWithTag("Boss") == null) // boss dead
        {
            EndPanel.SetActive(true);
            ImageObject.SetActive(true);
        }
        else if (GameObject.FindGameObjectWithTag("Player") == null) // player dead
        {
            EndPanel.SetActive(true);
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
        TotalScore += Score;
        ThisScoreTxt.text = TotalScore.ToString();
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
        SceneManager.LoadScene("SampleScene");
    }

    public enum Difficulty
    {
        basic =1,
        standard,
        challenge
    }   

    public void ChooseDifficulty()
    {
        if(difficulty == Difficulty.basic)
        {
            //basic�� �����ؼ� �ε�
        }
        else if(difficulty == Difficulty.standard)
        {
            // normal�� �����ؼ� �ε�
        }
        else if (difficulty == Difficulty.challenge)
        {
            //hard�� �����ؼ� �ε�
        }
       
    }
   
}
