using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public static int IsMoving = Animator.StringToHash(nameof(IsMoving));
    public static int IsAttack = Animator.StringToHash(nameof(IsAttack));

    [SerializeField] private Animator _animator;            
    [SerializeField] private CombatStats _combatStats;
    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private void OnEnable()
    {
        _combatStats.HitRecived += HitRecived;
    }

    private void OnDisable()
    {
        _combatStats.HitRecived -= HitRecived;
    }

    public void SetMovingAnimation(bool isCanMove)
    {
        _animator.SetBool(IsMoving, isCanMove);
    }

    public void SetAttackingAnimation(bool isCanAttack) 
    {
        _animator.SetBool(IsAttack, isCanAttack);
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
