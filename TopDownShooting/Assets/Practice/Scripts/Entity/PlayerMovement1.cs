using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Practice.Scripts.Entity
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement1 : MonoBehaviour
    {
        [SerializeField] private float speed;

        private TopDownCharacterController1 _controller;

        private Vector2 _direction;
        private Rigidbody2D _rigid;
        private Animator _ani;
        private void Awake()
        {
            _controller = GetComponent<TopDownCharacterController1>();
            _rigid = GetComponent<Rigidbody2D>();
            _ani = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            _controller.OnMoveEvent += Move;
        }
        

        private void Move(Vector2 direction)
        {
            Moving(direction);
        }

        private void Moving(Vector2 direction)
        {
            _direction = direction;
            _rigid.velocity = direction * speed;
            _ani.SetBool("IsMove",direction.magnitude>0);
        }
    }
}