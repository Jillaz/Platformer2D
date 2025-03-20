using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    private const string Fire1 = nameof(Fire1);

    public float Direction { get; private set; }
    public bool IsJump { get; private set; }

    [SerializeField] private CharacterAnimator _animator;    

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);
        _animator.PlayMovingAnimation(Direction);

        if (Input.GetButton(Jump))
        {
            IsJump = true;
        }
        else
        {
            IsJump = false;
        }

        if (Input.GetButton(Fire1))
        {
            _animator.PlayAttackAnimation();
        }
    }
}
