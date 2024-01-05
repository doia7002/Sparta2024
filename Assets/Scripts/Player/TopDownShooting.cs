using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _contoller;
    [SerializeField] private Transform projectileSpawnPosition;
    public GameObject testPrefab;

    private void Awake()
    {
        _contoller = GetComponent<TopDownCharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _contoller.OnAttackEvent += CreateProjectile;
        
    }
    private void CreateProjectile()
    {
        Vector2 sqawnPosition = projectileSpawnPosition.position;
        sqawnPosition.y = 40;
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }

   
}
