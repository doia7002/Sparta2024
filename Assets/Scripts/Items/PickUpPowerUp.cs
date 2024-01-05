using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : PickupItem
{
    [SerializeField] float PowerUpValue = 10;
    
    private void Start()
    {
    
    }

    protected override void OnPickedUp(GameObject receiver)
    {
    
    }
}
