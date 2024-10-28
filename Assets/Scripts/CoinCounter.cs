using UnityEngine;
using UnityEngine.Events;

public class CoinCounter : MonoBehaviour
{    
    [SerializeField] private CoinCollector _collector;
    private int _coinCount = 0;

    public UnityAction<int> CoinsNumberChanged;

    private void Start()
    {    
        _collector.CoinCollected += AddCoin;
    }

    private void AddCoin()
    {
        _coinCount++;     
        CoinsNumberChanged?.Invoke(_coinCount);
    }
}
