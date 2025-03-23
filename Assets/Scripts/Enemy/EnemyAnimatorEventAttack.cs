using UnityEngine;

public class EnemyAnimatorEventAttack : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;
    [SerializeField] private CharacterAbilities _characterAbilites;
    [SerializeField] private EnemyAttackRangeDetector _attackRangeDetector;

    private Health _target;    

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

    public void AttackTarget()
    {
        if (_target != null)
        {
            _target.TakeDamage(_characterAbilites.DealDamage());
        }
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
