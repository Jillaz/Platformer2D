using UnityEngine;
using System;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private ItemsCollector _collector;

    private int _coinCount = 0;

    public event Action<int> CoinsNumberChanged;

    private void OnEnable()
    {
        _collector.CoinCollected += AddCoin;        
    }

    private void OnDisable()
    {
        _collector.CoinCollected -= AddCoin;
    }

    private void AddCoin(int coinCost)
    {
        _coinCount += coinCost;
        CoinsNumberChanged?.Invoke(_coinCount);
    }
}
