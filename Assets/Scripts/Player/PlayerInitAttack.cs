using UnityEngine;

public class PlayerInitAttack : MonoBehaviour
{
    [SerializeField] private CombatStats _combatStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CombatStats enemy))
        {
            enemy.ApplyDamage(_combatStats.Hit());
        }
    }
}
