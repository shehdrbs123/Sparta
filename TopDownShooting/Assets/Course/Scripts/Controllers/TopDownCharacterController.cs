using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TopDownCharacterController : MonoBehaviour
{
    // 외부에서 호출하지 못하도록 만듬, 나만 쓸 수 있게?
    public event Action<Vector2> OnMoveEvent ;
    public event Action<Vector2> OnLookEvent ;

    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    // Start is called before the first frame update

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.2f)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > 0.2f)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // null이 아닐때만 작동
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
