using UnityEngine;
using UnityEngine.Events;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private CoinCollector _collector;
    private int _coinCount = 0;

    public event UnityAction<int> CoinsNumberChanged;

    private void Start()
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
