using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorActivator : MonoBehaviour
{
    private Animator Animator;

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCheck();
    }

    private void MoveCheck()
    {
        if (rigid.velocity.sqrMagnitude > 0f)
            Animator.SetBool("IsMove",true);
        else
            Animator.SetBool("IsMove",false);
    }
}
