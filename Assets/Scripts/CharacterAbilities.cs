using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    [SerializeField] private CharacterAttackPower _characterAttackPower;

    public int DealDamage()
    {
        return _characterAttackPower.AttackPower;
    }
}
