using System;
using TMPro;
using UnityEngine;

public class PlayerSelectBtn : MonoBehaviour
{
    public PlayerSO PlayerData;
    private TMP_Text _spriteName;

    private void Start()
    {
        _spriteName = GetComponentInChildren<TMP_Text>();
        //Debug.Log("TextMeshPro : " + _spriteName.text);
    }

    public void SetPlayerSO()
    {
        Enum.TryParse(_spriteName.text, out PlayerData.Type);
        PlayerData.SpriteName = $"{_spriteName.text}2";
        PlayerData.SpriteImage = Resources.Load<Sprite>($"Images/{_spriteName.text}2");
    }
}
