using UnityEngine;
using System;

public class EnemyAttackRangeDetector : MonoBehaviour
{
    public CombatStats SelectedTarget { get; private set; }

    public event Action PlayerEnteredAttackRange;
    public event Action PlayerLeftAttackRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CombatStats target))
        {
            SelectedTarget = target;
            PlayerEnteredAttackRange?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerLeftAttackRange?.Invoke();
    }
}
