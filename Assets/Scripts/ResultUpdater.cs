using UnityEngine;
using TMPro;

public class ResultUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoinCollector _collector;
    private int _coinCount = 0;
    private string _defaultString;

    private void Start()
    {
        _defaultString = _text.text;
        _text.text = _defaultString + _coinCount.ToString();
        _collector.CoinCollected += AddCoin;
    }

    private void AddCoin()
    {
        _coinCount++;
        _text.text = _defaultString + _coinCount.ToString();
    }
}
