using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out CombatStats combatStats))
        {
            combatStats.ApplyDamage(combatStats.Health);
        }
    }
}
