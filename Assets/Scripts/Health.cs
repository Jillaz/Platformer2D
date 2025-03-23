using System;
using UnityEngine;

public class Health : MonoBehaviour
{    
    public event Action CharacterDied;
    public event Action<int> ValueUpdated;
    public event Action Hitted;

    [field: SerializeField] public int MaxValue { get; private set; } = 100;
    [field: SerializeField] public int Value { get; private set; } = 50;
    [field: SerializeField] public int LethalValue { get; private set; } = 0;

    public void TakeDamage(int damage)
    {
        Value -= Mathf.Clamp(damage, LethalValue, int.MaxValue);
        Hitted?.Invoke();
        ValueUpdated?.Invoke(Value);

        if (Value <= LethalValue)
        {
            Value = LethalValue;            
            CharacterDied?.Invoke();
            ValueUpdated?.Invoke(Value);
        }
    }

    public void Healing(int healingAmount)
    {
        Value += Mathf.Clamp(healingAmount, LethalValue, MaxValue - Value);
        ValueUpdated?.Invoke(Value);
    }

    public void TakeLethalDamage()
    {
        TakeDamage(Value);
    }

    public void Ressurect()
    {
        Value = MaxValue;
    }
}
