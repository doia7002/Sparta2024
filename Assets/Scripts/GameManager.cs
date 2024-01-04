using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject endPanel;    
    public GameObject imageObject;
    public Text thisScoreTxt;
    public Text maxScoreTxt;
    int totalScore;
    public int Life = 3;
    public static GameManager instance = null;

    void Awake()
    {
        instance = this;
    }
    

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();            
        }
        
    }

    public void EndPanel()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
        /*if ()
        {
            endPanel.SetActive(true);
            imageObject.SetActive(true);
        }
        else if ()
        {
            endPanel.SetActive(true);
        }
        thisScoreTxt.text = totalScore.ToString();
        if (PlayerPrefs.HasKey("bestscore") == false)
        {
            PlayerPrefs.SetFloat("bestscore", totalScore);
        }
        else
        {
            if (totalScore > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", totalScore);
            }
        }
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScoreTxt.text = maxScore.ToString("N2");*/

    }
    public void addScore(int Score)
    {
        totalScore += Score;
        thisScoreTxt.text = totalScore.ToString();
    }

    public void LoseLife()
    {
        if (Life > 0)
        {
            Life--;
        }
        else
        {
           EndPanel();
        }
    }


    void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        
    }
    public void NextGame()
    {
        SceneManager.LoadScene("MapScene 1");
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
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
}
