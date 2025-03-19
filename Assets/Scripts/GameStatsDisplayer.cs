using UnityEngine;
using TMPro;

public class GameStatsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCoinsCollected;
    [SerializeField] private TextMeshProUGUI _textCurrentHealth;
    [SerializeField] private CoinCounter _coinCounter;
    [SerializeField] private CharacterStats _characterStats;

    private string _defaultStringCoins;
    private string _defaultStringHealth;

    private void OnEnable()
    {
        _coinCounter.CoinsNumberChanged += DisplayCoins;
        _characterStats.HealthUpdated += DisplayHealth;
    }

    private void OnDisable()
    {
        _coinCounter.CoinsNumberChanged -= DisplayCoins;
        _characterStats.HealthUpdated -= DisplayHealth;
    }

    private void Start()
    {
        _defaultStringCoins = _textCoinsCollected.text;
        _defaultStringHealth = _textCurrentHealth.text;        
        DisplayHealth(_characterStats.Health);
    }

    private void DisplayCoins(int coins)
    {
        _textCoinsCollected.text = _defaultStringCoins + coins;
    }

    private void DisplayHealth(int health)
    {
        _textCurrentHealth.text = $"{_defaultStringHealth}: {health}/{_characterStats.MaxHealth}";
    }
}
