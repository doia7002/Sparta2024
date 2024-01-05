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
	public float damage = 10;

    [Header("Difficulty")]
    public Level Level;
}

