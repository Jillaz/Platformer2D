using UnityEngine;
using System;

public class EnemyAttackRangeDetector : MonoBehaviour
{
    public event Action PlayerEnteredAttackRange;
    public event Action PlayerLeftAttackRange;

    public CharacterStats SelectedTarget { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterStats target))
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
