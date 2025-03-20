using UnityEngine;
using System;

public class ItemsCollector : MonoBehaviour
{
    public event Action<int> CoinCollected;
    public event Action<int> FirstAidKitCollected;

    [SerializeField] private CharacterHealth _characterHealth;

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
            _characterHealth.ApplyHeal(firstAidKit.HealthAmount);
            Destroy(collision.gameObject);
        }
    }
}
