using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting1 : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootTransform;
    
    private TopDownCharacterController1 _controller1;
    private Collider2D _cols;

    private float _rotZ=0;
    
    private void Awake()
    {
        _controller1 = GetComponent<TopDownCharacterController1>();
        _cols = GetComponent<Collider2D>();
    }

    
    private void Start()
    {
        _controller1.OnLookEvent += OnAim;
        _controller1.OnAttackEvent += OnShoot;
    }

    private void OnShoot()
    {
        Shooting();
    }

    private void Shooting()
    {
        GameObject obj = Instantiate(projectilePrefab, shootTransform.position, Quaternion.Euler(0,0,_rotZ));
        Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(),_cols);
        Destroy(obj,10);
    }

    private void OnAim(Vector2 newDirection)
    {
        _rotZ = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
    }
}
