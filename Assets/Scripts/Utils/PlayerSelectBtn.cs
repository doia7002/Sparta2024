using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectBtn : MonoBehaviour
{
    public GameSetSO GameSetData;
    private TMP_Text _buttonText;

    private void Start()
    {
        Image characterImage = transform.parent.GetChild(0).GetComponent<Image>();
        string spriteName = characterImage.sprite.name;

        string playerSpriteName = spriteName.Substring(0, spriteName.Length - 1);

        _buttonText = GetComponentInChildren<TMP_Text>();
        _buttonText.text = playerSpriteName;
    }

    public void SelectPlayer()
    {
        SetGameSetSO();
        UIManager.Instance.ChangeUI(UINumber.playerSelect, UINumber.level);
    }

    private void SetGameSetSO()
    {
        Enum.TryParse(_buttonText.text, out GameSetData.Type);
        GameSetData.SpriteName = $"{_buttonText.text}2";
        GameSetData.SpriteImage = Resources.Load<Sprite>($"Images/{_buttonText.text}2");
    }
}
