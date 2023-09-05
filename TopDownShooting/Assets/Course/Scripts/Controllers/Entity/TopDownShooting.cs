using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _Controller;
    private Vector3 ProjectileSpawnPoint;
    private Vector2 _aimDirection = Vector2.right;

    [SerializeField] private GameObject projectilePrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        _Controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _Controller.OnAttackEvent += OnShoot;
        _Controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 obj)
    {
        _aimDirection = obj;
    }

    private void OnShoot()
    {
        Shoot();
    }

    private void Shoot()
    {
        float rotZ = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;
        Instantiate(projectilePrefab, ProjectileSpawnPoint,Quaternion.Euler(0,0,rotZ));
    }

    private

    // Update is called once per frame
    void Update()
    {
        
    }
}
