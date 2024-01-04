using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public void RetryGame()
    {
        GameManager.instance.Retry1();
    }
    public void RetryGame2()
    {
        GameManager.instance.Retry2();
    }

    public void ExitGame()
    {
        GameManager.instance.Exit();
    }

    public void ResumeGame()
    {
        GameManager.instance.Resume();
    }

    public void NextGame()
    {
        GameManager.instance.NextGame();
    }
}
