using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    public bool Pause { get; set; }

    private void Awake()
    {
        _camera = Camera.main;
    }
    
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }

    public void OnItem() 
    {
        BombManager.Instance.UseBomb();
    }

    public void OnPause()
    {
        GameManager.Instance.Pause();
    }
}
