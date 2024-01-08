using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (canBePickupBy.value == LayerMask.GetMask("Monster"))
        {
            OnPickedUp(other.gameObject);
            

            if (destroyOnPickup)
            {
                
                Destroy(gameObject);
            }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);
}
