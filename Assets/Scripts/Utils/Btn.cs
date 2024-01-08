using UnityEngine;

public class Btn : MonoBehaviour
{
    public void RetryGame()
    {
        GameManager.Instance.Retry1();
    }

    public void RetryGame2()
    {
        GameManager.Instance.Retry2();
    }

    public void ExitGame()
    {
        GameManager.Instance.Exit();
    }

    public void ResumeGame()
    {
        GameManager.Instance.Resume();
    }

    public void NextGame()
    {
        GameManager.Instance.NextGame();
    }
}
