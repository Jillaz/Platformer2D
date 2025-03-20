using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimator : MonoBehaviour
{
    public static int IsMoving = Animator.StringToHash(nameof(IsMoving));

    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayMovingAnimation(bool isCanMove)
    {
        _animator.SetBool(IsMoving, isCanMove);
    }

    public void PlayMovingAnimation(float direction)
    {
        _animator.SetBool(IsMoving, direction != 0);
    }

    public void PlayAttackAnimation()
    {
        _animator.Play(_attack.name);
    }

    public void PlayHitRecivedAnimation()
    {
        _animator.Play(_hitted.name);
    }
}
