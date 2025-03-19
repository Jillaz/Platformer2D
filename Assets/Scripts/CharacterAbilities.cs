using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;

    public int Attack()
    {
        return _characterStats.AttackPower;
    }
}
