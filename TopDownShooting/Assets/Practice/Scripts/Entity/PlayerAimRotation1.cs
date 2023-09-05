using System;
using UnityEngine;
namespace Practice.Scripts.Entity
{
    public class PlayerAimRotation1 : MonoBehaviour
    {
        private TopDownCharacterController1 _controller;

        [SerializeField] private SpriteRenderer _rangeWeaponRenderer;
        [SerializeField] private Transform _rangePivot;
        [SerializeField] private SpriteRenderer _meleeWeaponRenderer;
        [SerializeField] private Transform _meleePivot;
        [SerializeField] private Transform _meleeSpriteTransform;
        [SerializeField] private SpriteRenderer _characterRenderer;

        private Vector2 defaultLocalMeleeSpritePos;


        private Vector2 _LookPosition;
        public void Awake()
        {
            _controller = GetComponent<TopDownCharacterController1>();
        }

        public void Start()
        {
            defaultLocalMeleeSpritePos = _meleeSpriteTransform.localPosition;
            _controller.OnLookEvent += Look;            
        }

        private void Look(Vector2 newDirection)
        {
            Rotate(newDirection);
        }
        
        private void Rotate(Vector2 look)
        {
            float rotZ = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

            _rangeWeaponRenderer.flipY = Mathf.Abs(rotZ) > 90f;
            _meleeWeaponRenderer.flipY = _rangeWeaponRenderer.flipY;
            _characterRenderer.flipX = _rangeWeaponRenderer.flipY;

            _rangePivot.rotation = Quaternion.Euler(0, 0, rotZ);
            _meleePivot.rotation = _rangePivot.rotation;
            
            if (_meleeWeaponRenderer.flipY)
                _meleeSpriteTransform.localPosition = new Vector2(defaultLocalMeleeSpritePos.x, -defaultLocalMeleeSpritePos.y);
            else
                _meleeSpriteTransform.localPosition = new Vector2(defaultLocalMeleeSpritePos.x, defaultLocalMeleeSpritePos.y);

        }
    }
}