using UnityEngine;

public class EnemyAnimatorEventAttack : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private CharacterAbilities _characterAbilites;
    [SerializeField] private EnemyAttackRangeDetector _attackRangeDetector;

    private CharacterStats _target;

    public void Attack()
    {
        if (_target != null)
        {
            _target.ApplyDamage(_characterAbilites.Attack());
        }
    }

    private void OnEnable()
    {
        _attackRangeDetector.PlayerEnteredAttackRange += SetTarget;
        _attackRangeDetector.PlayerLeftAttackRange += ClearTarget;
    }

    private void OnDisable()
    {
        _attackRangeDetector.PlayerEnteredAttackRange -= SetTarget;
        _attackRangeDetector.PlayerLeftAttackRange -= ClearTarget;
    }

    private void Start()
    {
        _target = null;
    }

    private void SetTarget()
    {
        _target = _attackRangeDetector.SelectedTarget;
    }

    private void ClearTarget()
    {
        _target = null;
    }    
}
