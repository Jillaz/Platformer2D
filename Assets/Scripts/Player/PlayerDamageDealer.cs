using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private CharacterAbilities _characterAbilities;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
        {
            enemy.TakeDamage(_characterAbilities.DealDamage());
        }
    }
}
