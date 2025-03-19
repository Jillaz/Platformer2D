using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private CharacterAbilities _characterAbilities;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterStats enemy))
        {
            enemy.ApplyDamage(_characterAbilities.Attack());
        }
    }
}
