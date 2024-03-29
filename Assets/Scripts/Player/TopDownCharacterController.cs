using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnAttackEvent;

    public GameObject _enemyBullet { get; set; }

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected bool UsingItem { get; set; }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.2f)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > 0.2f)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
    
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    { 
        OnAttackEvent?.Invoke();
    }
}
