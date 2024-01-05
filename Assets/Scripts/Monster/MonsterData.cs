using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Melee,
    Range,
    Boss
}


[CreateAssetMenu(fileName = "Monster", menuName = "New Monster")]
public class MonsterData : ScriptableObject
{
    [Header("Info")]
    public MonsterType type;
    public int maxhp = 10;
    public float speed;
    public int score;

}


