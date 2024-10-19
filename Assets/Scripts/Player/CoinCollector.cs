using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    public UnityAction CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin _))
        {
            CoinCollected?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
