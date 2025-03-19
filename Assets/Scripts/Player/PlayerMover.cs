using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ModelFlipper _modelFlipper;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        JumpUp();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_playerInput.Direction * _moveSpeed, _rigidbody.velocity.y);
        _modelFlipper.FlipRotation(_playerInput.Direction);
    }

    private void JumpUp()
    {
        if (_groundChecker.IsGrounded() && _playerInput.IsJump)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }
}
