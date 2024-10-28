using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public static int IsRunning = Animator.StringToHash(nameof(IsRunning));

    [SerializeField] private PlayerInput _playerInput;    
    [SerializeField] private Animator _animator;
    private Vector2 _scaleLookRight;
    private Vector2 _scaleLookLeft;

    private void Start()
    {
        _scaleLookRight = new Vector2(transform.localScale.x, transform.localScale.y);
        _scaleLookLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void Update()
    {
        FlipScale(_playerInput.Direction);
        AnimateMovement(_playerInput.Direction);
    }

    private void FlipScale(float direction)
    {
        if (direction > 0)
        {
            transform.localScale = _scaleLookRight;

        }
        if (direction < 0)
        {
            transform.localScale = _scaleLookLeft;
        }
    }

    private void AnimateMovement(float direction)
    {
        _animator.SetBool(IsRunning, direction != 0);
    }
}
