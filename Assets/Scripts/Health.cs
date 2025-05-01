using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Died;
    public event Action<float> ValueUpdated;
    public event Action Hitted;

    [field: SerializeField] public float MaxValue { get; private set; } = 100;
    [field: SerializeField] public float Value { get; private set; } = 50;
    [field: SerializeField] public float MinValue { get; private set; } = 0;

    public void TakeDamage(float damage)
    {
        damage = CheckNegativeValue(damage);
        Value -= damage;
        Value = Math.Clamp(Value, MinValue, MaxValue);
        Hitted?.Invoke();

        if (damage == 0)
        {
            return;
        }

        ValueUpdated?.Invoke(Value);

        if (Value == MinValue)
        {
            Died?.Invoke();
            ValueUpdated?.Invoke(Value);
        }
    }

    public void Healing(float healingAmount)
    {
        healingAmount = CheckNegativeValue(healingAmount);
        Value += healingAmount;
        Value = Math.Clamp(Value, MinValue, MaxValue);

        if (healingAmount == 0)
        {
            return;
        }

        ValueUpdated?.Invoke(Value);
    }

    public void Kill()
    {
        TakeDamage(Value);
    }

    public void Ressurect()
    {
        Value = MaxValue;
    }

    private float CheckNegativeValue(float value)
    {
        if (value < 0)
        {
            return 0;
        }
        else
        {
            return value;
        }
    }
}
