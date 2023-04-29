using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private Vector2 _movementInput;
        private Vector2 _smoothedMovementInput;
        private Vector2 _smoothedMovementVelocity;

        [SerializeField] private float speed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput,
                ref _smoothedMovementVelocity, 0.1f);
            _rigidbody2D.velocity = _smoothedMovementInput;
        }

        private void OnMove(InputValue inputValue)
        {
            _movementInput = inputValue.Get<Vector2>() * speed;
        }
    }
}