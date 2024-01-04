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


    // ���� �̱��� ����� �ϴ� �޼��峪 �������� �߰��� �� �ֽ��ϴ�.
    private void Awake()
    {
        Instance = this;
    }
}
