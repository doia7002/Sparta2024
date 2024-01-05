using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDamage : PickupItem
{
    [SerializeField] int DamageValue = 10;
    

    protected override void OnPickedUp(GameObject receiver)
    {
        
    }

}
