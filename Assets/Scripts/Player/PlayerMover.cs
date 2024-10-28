using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private void Update()
    {
        Move();            
    }

    private void FixedUpdate()
    {
        JumpUp();
    }

    private void Move()
    {
        transform.Translate(_playerInput.Direction * _moveSpeed * Time.deltaTime * Vector2.right);
    }

    private void JumpUp()
    {
        if (_groundChecker.IsGrounded() && _playerInput.IsJump)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }    
}
