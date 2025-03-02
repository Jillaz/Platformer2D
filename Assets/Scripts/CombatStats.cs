using UnityEngine;
using UnityEngine.Events;

public class CombatStats : MonoBehaviour
{
    [field: SerializeField] public int Health { get; private set; } = 100;
    [field: SerializeField] public int DeadlyHealthLevel { get; private set; } = 0;
    [field: SerializeField] public int AttackPower { get; private set; } = 20;    
    
    public event UnityAction SuddenDeath;
    public event UnityAction HitRecived;
    public event UnityAction<int> HealthUpdated;

    public void ApplyDamage(int damage)
    {
        Health -= damage;        
        HitRecived?.Invoke();
        HealthUpdated?.Invoke(Health);

        if (Health <= DeadlyHealthLevel)
        {
            SuddenDeath?.Invoke();
        }
    }

    public int Hit()
    {
        return AttackPower;
    }

    public void Healing(int healingAmount)
    {
        Health += healingAmount;
        HealthUpdated?.Invoke(Health);
    }
}
