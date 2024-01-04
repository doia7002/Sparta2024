using UnityEngine;

public class Animations : MonoBehaviour
{
    protected Animator Animator;
    protected TopDownCharacterController controller;

    protected virtual void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownCharacterController>();
    }
}
