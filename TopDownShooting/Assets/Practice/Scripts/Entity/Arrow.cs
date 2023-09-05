using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * arrowSpeed;
    }

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(rigid.velocity);
    }
}
