using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private RangedAttackData _attackData;
    private float _currentDuration;
    private Vector2 _direction;
    private bool _isReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;
    private ProjectileManager _projectileManager;

    public bool fxOnDestory = true;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (_isReady)
            return;

        _currentDuration += Time.deltaTime;

        if (_currentDuration > _attackData.duration)
            DestoryProjectile(transform.position, false);

        _rigidbody.velocity = _direction * _attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << other.gameObject.layer)))
        {
            DestoryProjectile(other.ClosestPoint(transform.position) - _direction*.2f,fxOnDestory);
        }
    }
    
    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {
        _projectileManager = projectileManager;
        _attackData = attackData;
        _direction = direction;

        UpdateProjectileSprite();
        _trailRenderer.Clear();
        _currentDuration = 0;
        _spriteRenderer.color = attackData.projectileColor;

        transform.right = _direction;
        _isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestoryProjectile(Vector3 transformPosition, bool createFx)
    {
        if (createFx)
        {
            
        }
        gameObject.SetActive(false);
    }

   
}
