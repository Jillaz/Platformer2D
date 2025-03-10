using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private List<Transform> _spawnpoints = new List<Transform>();

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (var item in _spawnpoints)
        {
            Instantiate(_itemPrefab, item.position, Quaternion.identity);
        }
    }
}
