using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneLoad : MonoBehaviour
{
    public void LoadMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }
}
