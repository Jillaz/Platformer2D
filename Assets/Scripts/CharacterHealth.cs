using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public event Action CharacterDied;
    public event Action<int> HealthUpdated;

    [field: SerializeField] public int MaxHealth { get; private set; } = 100;
    [field: SerializeField] public int Health { get; private set; } = 50;
    [field: SerializeField] public int LethalValueHealth { get; private set; } = 0;

    [SerializeField] private CharacterAnimator _animator;

    public void ApplyDamage(int damage)
    {
        Health -= Mathf.Clamp(damage, LethalValueHealth, int.MaxValue);
        _animator.PlayHitRecivedAnimation();
        HealthUpdated?.Invoke(Health);

        if (Health <= LethalValueHealth)
        {
            Health = LethalValueHealth;            
            CharacterDied?.Invoke();
            HealthUpdated?.Invoke(Health);
        }
    }

    public void ApplyHeal(int healingAmount)
    {
        Health += Mathf.Clamp(healingAmount, LethalValueHealth, MaxHealth - Health);
        HealthUpdated?.Invoke(Health);
    }

    public void ApplyLethalDamage()
    {
        ApplyDamage(Health);
    }

    public void Ressurect()
    {
        Health = MaxHealth;
    }
}
