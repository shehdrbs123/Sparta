using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerShooting1 : MonoBehaviour
{
    [SerializeField] private Transform shootTransform;

    private ProjectileManager _projectileManager;
    private TopDownCharacterController1 _controller1;
    private Collider2D _cols;

    private float _rotZ=0;
    private Vector2 _aimDirection;
    
    private void Awake()
    {
        _controller1 = GetComponent<TopDownCharacterController1>();
        _cols = GetComponent<Collider2D>();
    }

    
    private void Start()
    {
        _projectileManager = ProjectileManager.instance;
        _controller1.OnLookEvent += OnAim;
        _controller1.OnAttackEvent += OnShoot;
    }

    private void OnShoot(AttackSO attackSo)
    {
        Shooting(attackSo);
    }

    private void Shooting(AttackSO attackSo)
    {
        RangedAttackData rangedAttackData = attackSo as RangedAttackData;

        float projectileAngleSpace = rangedAttackData.multipleProjectileAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectileAngleSpace +
                         0.5f * rangedAttackData.multipleProjectileAngel;

        for (int i = 0; i < numberOfProjectilesPerShot; ++i)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
        
        // GameObject obj = Instantiate(projectilePrefab, shootTransform.position, Quaternion.Euler(0,0,_rotZ));
        // Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(),_cols);
        // Destroy(obj,10);
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
            shootTransform.position,
            RotateVector2(_aimDirection,angle),
            rangedAttackData);
    }

    private Vector2 RotateVector2(Vector2 aimDirection, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * aimDirection;
    }

    private void OnAim(Vector2 newDirection)
    {
        _rotZ = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        _aimDirection = newDirection;
    }
}
