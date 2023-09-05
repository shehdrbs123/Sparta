using System;
using UnityEngine.InputSystem;
using UnityEngine;
namespace Practice.Scripts
{
    public class PlayerInputController1 : TopDownCharacterController1
    {
        private Camera _Camera;

        private Vector2 _mouseWorldPosition;
        private void Awake()
        {
            _Camera = Camera.main;
        }

        private void LateUpdate()
        {
           LookFor();
        }

        public void OnMove(InputValue value)
        {
            Vector2 Direction = value.Get<Vector2>().normalized;
            CallMoveEvent(Direction);
        }

        public void OnLook(InputValue value)
        {
            _mouseWorldPosition = value.Get<Vector2>();
        }

        public void LookFor()
        {
            Vector2 worldPos = _Camera.ScreenToWorldPoint(_mouseWorldPosition);
            Vector2 direction = (worldPos - (Vector2)transform.position).normalized;
            if (direction.magnitude > .9f)
            {
                CallLookEvent(direction);
            }
        }

        public void OnFire()
        {
            IsAttacking = true;
        }
    }
}