using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static int IsRunning = Animator.StringToHash(nameof(IsRunning));    

    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;
    [SerializeField] GroundChecker _groundChecker;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpForce;

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
        float direction = Input.GetAxis(Horizontal);        

        FlipSprite(direction);
        AnimateMovement(direction);
        transform.Translate(direction * _moveSpeed * Time.deltaTime * Vector2.right);
    }

    private void JumpUp()
    {
        if (Input.GetButton(Jump) && _groundChecker.IsGrounded())
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }    

    private void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            _spriteRenderer.flipX = false;

        }
        if (direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void AnimateMovement(float direction)
    {
        if (direction != 0)
        {
            _animator.SetBool(IsRunning, true);
        }
        else
        {
            _animator.SetBool(IsRunning, false);
        }
    }
}
