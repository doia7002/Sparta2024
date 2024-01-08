using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerActive;

    public void IsTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            PlayerActive.SetActive(false);
            Debug.Log("Damaged");

        }

    }
    
}
