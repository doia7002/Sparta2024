using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;    
    public event Action OnAttackEvent;
    public event Action OnItemEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected bool UsingItem { get; set; }
    public bool GameObject;
    
    
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
    public void ItemUsed()//������
    {
        if (UsingItem)
        {
            

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
    public void CallItemEvent()//������
    {
        OnItemEvent?.Invoke();
    }
    


}
