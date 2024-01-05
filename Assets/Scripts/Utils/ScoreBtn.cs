using UnityEngine;


public class ScoreBtn : MonoBehaviour
{
    public void ScoreBoard()
    {
        UIManager.Instance.ChangeUI(UINumber.start, UINumber.score);
    }
}
