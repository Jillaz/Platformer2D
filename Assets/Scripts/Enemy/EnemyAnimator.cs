using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimator : MonoBehaviour
{
    public static int IsMoving = Animator.StringToHash(nameof(IsMoving));
    public static int IsAttack = Animator.StringToHash(nameof(IsAttack));

    [SerializeField] private CharacterHealth _characterHealth;
    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _characterHealth.HitRecived += HitRecived;
    }

    private void OnDisable()
    {
        _characterHealth.HitRecived -= HitRecived;
    }

    public void SetMovingAnimation(bool isCanMove)
    {
        _animator.SetBool(IsMoving, isCanMove);
    }

    public void Attack()
    {
        _animator.Play(_attack.name);
    }

    private void HitRecived()
    {
        _animator.Play(_hitted.name);
    }
}
