using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private Vector2 _movementInput;

        [Header("Animation")]
        [SerializeField] Animator animator;


        [Header("Movement Speed")]
        [SerializeField] private float accSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float decSpeed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Vector2 _velocity = _rigidbody2D.velocity;
            Vector2 _velocitySign = new Vector2(Math.Sign(_rigidbody2D.velocity.x), Math.Sign(_rigidbody2D.velocity.y));
            Vector2 _movementInputSign = new Vector2(Math.Sign(_movementInput.x), Math.Sign(_movementInput.y));

            // velocity is 0 if velocity is less than decspeed
            if (_velocitySign.x * _velocity.x <= decSpeed && _movementInputSign.x == 0)
            {
                _velocity.x = 0;
                _velocitySign.x = 0;
            }
            if (_velocitySign.y * _velocity.y <= decSpeed && _movementInputSign.y == 0)
            {
                _velocity.y = 0;
                _velocitySign.y = 0;
            }
            // velocity is reduced if player isn´t moving in that direction
            if (_velocitySign.x != _movementInputSign.x)
            {
                _velocity.x += decSpeed * -_velocitySign.x;
            }
            if (_velocitySign.y != _movementInputSign.y)
            {
                _velocity.y += decSpeed * -_velocitySign.y;
            }
            _velocity += _movementInput.normalized * Mathf.Clamp(_movementInput.magnitude * accSpeed, -maxSpeed, maxSpeed);
            _rigidbody2D.velocity = _velocity;

            //Animation trigger
            animator.SetFloat("Movement Input", _movementInput.x);
        }

        private void OnMove(InputValue inputValue)
        {
            _movementInput = inputValue.Get<Vector2>().normalized;
        }
    }
}