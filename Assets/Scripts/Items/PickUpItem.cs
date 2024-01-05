using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ºÎµúÈû");
        if (canBePickupBy.value == (canBePickupBy.value | (1 << other.gameObject.layer)))
        {
            OnPickedUp(other.gameObject);
            Debug.Log("ÆÄ±«1");

            if (destroyOnPickup)
            {
                Debug.Log("ÆÄ±«");
                Destroy(gameObject);
            }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);
}
