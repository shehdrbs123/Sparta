using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _Camera;
    public void Awake()
    {
        _Camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 Direction = value.Get<Vector2>().normalized;
        CallMoveEvent(Direction);   
    }
    public void OnLook(InputValue value)
    {
        Vector2 ScreenPos = value.Get<Vector2>(); // 화면 좌표를 받아옴
        Vector2 WorldPos = _Camera.ScreenToWorldPoint(ScreenPos); // 화면좌표를 월드 좌표로 변환
        Vector2 newAim = (WorldPos - (Vector2)transform.position).normalized; // 캐릭터로부터 마우스 좌표의 방향을 구함

        if (newAim.magnitude >.9f)
        {
            CallLookEvent(newAim);// 그 값을 이벤트로 던짐            
        }
    }
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
