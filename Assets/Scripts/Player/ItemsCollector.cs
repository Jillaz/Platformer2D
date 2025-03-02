using UnityEngine;
using UnityEngine.Events;

public class ItemsCollector : MonoBehaviour
{
    [SerializeField] private CombatStats _combatStats;

    public event UnityAction<int> CoinCollected;
    public event UnityAction<int> FirstAidKitCollected;

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
