using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimator : MonoBehaviour
{
    private static int IsMoving = Animator.StringToHash(nameof(IsMoving));

    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;
    [SerializeField] private Health _characterHealth;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }    

    private void OnEnable()
    {
        _characterHealth.Hitted += PlayHitRecivedAnimation;
    }

    private void OnDisable()
    {
        _characterHealth.Hitted -= PlayHitRecivedAnimation;
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

    private void PlayHitRecivedAnimation()
    {
        _animator.Play(_hitted.name);
    }
}
