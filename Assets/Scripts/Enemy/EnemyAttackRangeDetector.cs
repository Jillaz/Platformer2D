using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackRangeDetector : MonoBehaviour
{
    public CombatStats SelectedTarget {  get; private set; }
    public event UnityAction PlayerEnterAttackRange;
    public event UnityAction PlayerLeaveAttackRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CombatStats player))
        {
            PlayerEnterAttackRange?.Invoke();
            SelectedTarget = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerLeaveAttackRange?.Invoke();
    }
}
