using System;
using UnityEngine;

namespace Controllers.Entity
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TopDownMovement : MonoBehaviour
    {
        private TopDownCharacterController _controller;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementDirection = Vector2.zero;
        private void Awake()
        {
            _controller = GetComponent<TopDownCharacterController>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Start()
        { 
            _controller.OnMoveEvent += Move;
            _controller.OnLookEvent += Look;
        }   
        
        //실제 움직임 처리
        public void Move(Vector2 Direction)
        {
            _movementDirection = Direction;
            _rigidbody2D.velocity = _movementDirection * 5f;
        }

        // 실제 바라봄 처리
        public void Look(Vector2 Direction)
        {
            
        }
    }
}