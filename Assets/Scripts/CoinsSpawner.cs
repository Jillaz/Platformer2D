using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _spawnpoints = new List<Transform>();

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (var item in _spawnpoints)
        {
            Instantiate(_coin, item.position, Quaternion.identity);
        }
    }
}
