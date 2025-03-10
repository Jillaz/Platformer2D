using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    [SerializeField] private CombatStats _character;
    [SerializeField] private EnemyAttackRangeDetector _attackRangeDetector;

    private CombatStats _target;

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

    public void Attack()
    {
        if (_target != null)
        {
            _target.ApplyDamage(_character.Hit());
        }
    }
}
