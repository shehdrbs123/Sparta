using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Practice.Scripts.Common;
using Practice.Scripts.Managers;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;
    
    public static ProjectileManager instance;

    [SerializeField] private GameObject bullet;

    private GameObjectPool _pool;

    private void Awake()
    {
        instance = this;
        _pool = new GameObjectPool();
        _pool.Init(ClassGetter.GetResourcePrefabs<GameObject>(Path.Combine("Prefabs","Projectile")));
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = _pool.Get("Arrow");
        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);
        
        obj.SetActive(true);
    }
}
