using UnityEngine;

public enum MonsterBulletType
{
    Normal,
    Spread
}

[CreateAssetMenu(fileName = "MonsterBullet", menuName = "New Monster Bullet")]
public class MonsterBulletData : ScriptableObject
{
    [Header("Info")]
    public MonsterBulletType type;
    public float speed;
    public int BulletNumber;
}
