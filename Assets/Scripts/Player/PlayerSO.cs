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

[CreateAssetMenu(fileName = "Player", menuName = "PlayerChoice")]
public class PlayerSO : ScriptableObject
{
    [Header("Info")]
    public PlayerType Type;
    public string SpriteName;
    public Sprite SpriteImage;
    public float damage = 10.0f;
}

