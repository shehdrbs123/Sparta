using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine;

public class TopDownCharacterController1 : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    [CanBeNull] public event Action<Vector2> OnMoveEvent;

    [CanBeNull] public event Action<Vector2> OnLookEvent;
    [CanBeNull] public event Action OnAttackEvent;

    private float _timeSinceLastShoot = 0;
    protected bool IsAttacking = false;
    
    private void Update()
    {
        HandleAttackDelay();        
    }

    public void HandleAttackDelay()
    {
        if (_timeSinceLastShoot < attackDelay)
        {
            _timeSinceLastShoot += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastShoot >= attackDelay)
        {
            IsAttacking = false;
            CallAttackEvent();
        }
    }
    
    // Start is called before the first frame update


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 look)
    {
        OnLookEvent?.Invoke(look);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
