using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimator : MonoBehaviour
{
    public static int IsMoving = Animator.StringToHash(nameof(IsMoving));
    public static int IsAttack = Animator.StringToHash(nameof(IsAttack));

    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private Animator _animator;

    public void SetMovingAnimation(bool isCanMove)
    {
        _animator.SetBool(IsMoving, isCanMove);
    }

    public void Attack()
    {
        _animator.Play(_attack.name);
    }

    private void OnEnable()
    {
        _characterStats.HitRecived += HitRecived;
    }

    private void OnDisable()
    {
        _characterStats.HitRecived -= HitRecived;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }    

    private void HitRecived()
    {
        _animator.Play(_hitted.name);
    }
}
