using UnityEngine;
using System;

public class EnemyAttackRangeDetector : MonoBehaviour
{
    public event Action PlayerEnteredAttackRange;
    public event Action PlayerLeftAttackRange;

    public Health SelectedTarget { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health target))
        {
            SelectedTarget = target;
            PlayerEnteredAttackRange?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SelectedTarget = null;
        PlayerLeftAttackRange?.Invoke();
    }
}
