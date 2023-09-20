using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;
    public static ProjectileManager instance;

    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        instance = this;
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(bullet);

        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);
        
        obj.SetActive(true);
    }
}
