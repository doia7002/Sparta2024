using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectBtn : MonoBehaviour
{
    public GameSetSO GameSetData;
    private TMP_Text _buttonText;
    
    private void Start()
    {
        Image levelImage = transform.parent.GetChild(0).GetComponent<Image>();
        string spriteName = levelImage.sprite.name;

        string levelSpriteName = spriteName;

        _buttonText = GetComponentInChildren<TMP_Text>();
        _buttonText.text = levelSpriteName;
    }
    
    public void SelectLevel()
    {
        SetGameSetSO();
        SceneManager.LoadScene("Stage1");
    }
    
    private void SetGameSetSO()
    {
        Enum.TryParse(_buttonText.text, out GameSetData.Type);
    }
}
