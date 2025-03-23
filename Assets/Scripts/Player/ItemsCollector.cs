using UnityEngine;
using System;

public class ItemsCollector : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;

    public event Action<int> CoinCollected;
    public event Action<int> FirstAidKitCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.TryGetComponent(out Items item))
        {
            if (item is Coin)
            {
                CoinCollected?.Invoke(item.Value);
                Destroy(collision.gameObject);
            }
            else if (item is FirstAidKit)
            {
                FirstAidKitCollected?.Invoke(item.Value);
                _characterHealth.Healing(item.Value);
                Destroy(collision.gameObject);
            }
        }
    }
}
