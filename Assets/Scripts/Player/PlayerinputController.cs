using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    public bool Pause { get; set; }

    public void OnMove(InputValue value)
    {
        
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
        IsAttacking = value.isPressed;
    }
    public void OnItem(InputValue value) 
    {
        Debug.Log("OnItem"+value.ToString());
        UsingItem = value.isPressed;
    }
    
    

}
