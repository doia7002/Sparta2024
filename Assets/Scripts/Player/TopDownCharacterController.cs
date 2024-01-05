using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;    
    public event Action OnAttackEvent;
    public event Action OnItemEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected bool UsingItem { get; set; }

    public GameObject _enemyBullet;

    protected virtual void Update()
    {
        HandleAttackDelay();
        ItemUsed();
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
    public void ItemUsed()
    {
        if (UsingItem)
        {
            if (_enemyBullet == true)
            {
                GameObject bullet = _enemyBullet;
                bullet.SetActive(false);

            }
        }
        else
        {
            if (_enemyBullet != null)
            {
                GameObject bullet = _enemyBullet;
                bullet.SetActive(true);
            }
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
    public void CallItemEvent()
    {
        OnItemEvent?.Invoke();
    }



}
