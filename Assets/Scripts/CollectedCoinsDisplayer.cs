using UnityEngine;
using TMPro;

public class CollectedCoinsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoinCounter _coinCounter;
    private string _defaultString;

    private void Start()
    {
        _defaultString = _text.text;        
        _coinCounter.CoinsNumberChanged += DisplayResult;
    }

    private void DisplayResult(int coins)
    {
        _text.text = _defaultString + coins;
    }
}
