using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TopDownAimRotation : MonoBehaviour
{

    [SerializeField] private SpriteRenderer AimRenderer;

    [SerializeField] private SpriteRenderer PlayerRenderer;

    [SerializeField] private Transform AimPivot;

    private TopDownCharacterController _controller;
    // Start is called before the first frame update

    private void Awake()
    { 
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateAim(newAimDirection);
    }

    private void RotateAim(Vector2 newAimDirection)
    {
        float rotz = Mathf.Atan2(newAimDirection.y, newAimDirection.x) * Mathf.Rad2Deg;
        
        // 그림을 기준으로 y 플립 (y축 방향을 플립하는거,
        // 활은 위쪽과 아랫쪽이 나눠 질 수 있으므로, 활을 위아래로 플립해줌으로써 일치화
        AimRenderer.flipY = Mathf.Abs(rotz) > 90f;
        // 플레이어의 x축 방향을 플립하여, 에임의 방향을 볼 수 있도록함.
        PlayerRenderer.flipX = AimRenderer.flipY;
        AimPivot.rotation = Quaternion.Euler(0f, 0f, rotz);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
