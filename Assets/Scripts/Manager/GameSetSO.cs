using UnityEngine;

public enum PlayerType
{
    Yonguk,
    Wonjun,
    Wonjae,
    Inho,
    Hyeonkeun,
    Taeseong
}

[CreateAssetMenu(fileName = "GameSet", menuName = "PlayerChoice")]
public class GameSetSO : ScriptableObject
{
    [Header("Player")]
    public PlayerType Type;
    public string SpriteName;
    public Sprite SpriteImage;

    [Header("Difficulty")]
    public Level Level;
}
