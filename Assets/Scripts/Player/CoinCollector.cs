using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    public event UnityAction<int> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinCollected?.Invoke(coin.CoinCost);
            Destroy(collision.gameObject);
        }
    }
}
