using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public enum Difficulty
    {
        Beginner = 1,
        Intermediate,
        Advanced
    }

    private static TestManager Instance;


    // 실제 싱글톤 기능을 하는 메서드나 변수들을 추가할 수 있습니다.
    private void Awake()
    {
        Instance = this;
    }
}
