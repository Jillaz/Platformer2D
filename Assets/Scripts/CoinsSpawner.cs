using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    private List<Transform> _spawnpoints = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnpoints.Add(transform.GetChild(i));
        }
    }

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
