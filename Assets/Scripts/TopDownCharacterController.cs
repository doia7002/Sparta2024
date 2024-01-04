using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public event Action OnAttackEvent;
    public event Action OnItemEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected bool UsingItem { get; set; }

    protected virtual void Update()
    {
        HandleAttackDelay();
        Destroybullets();
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
    private void Destroybullets()
    { 
        if(UsingItem) 
        {
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
            {   
             Destroy(bullet);
                
            }
        }
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
