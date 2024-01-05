using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : PickupItem
{
    [SerializeField] float PowerUpValue = 10;
    public PlayerSO playerData;
    private void Start()
    {
        playerData = ScriptableObject.CreateInstance<PlayerSO>();
    }

    protected override void OnPickedUp(GameObject receiver)
    {
        

        if (playerData != null)
        {
            playerData.damage += PowerUpValue;
        }
    }
}
