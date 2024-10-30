using UnityEngine;

public class PlayerMover : MonoBehaviour
{    
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private void FixedUpdate()
    {
        Move();
        JumpUp();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_playerInput.Direction * _moveSpeed, _rigidbody.velocity.y);
    }

    private void JumpUp()
    {
        if (_groundChecker.IsGrounded() && _playerInput.IsJump)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;            
        }
    }
}
