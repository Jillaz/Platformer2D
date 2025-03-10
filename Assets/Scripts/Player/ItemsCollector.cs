using UnityEngine;
using System;

public class ItemsCollector : MonoBehaviour
{
    [SerializeField] private CombatStats _combatStats;

    public event Action<int> CoinCollected;
    public event Action<int> FirstAidKitCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinCollected?.Invoke(coin.CoinCost);
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent(out FirstAidKit firstAidKit))
        {
            FirstAidKitCollected?.Invoke(firstAidKit.HealthAmount);
            _combatStats.Healing(firstAidKit.HealthAmount);
            Destroy(collision.gameObject);
        }
    }
}
