using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    [SerializeField] private CharacterAttackPower _characterAttackPower;

    public int Attack()
    {
        return _characterAttackPower.AttackPower;
    }
}
