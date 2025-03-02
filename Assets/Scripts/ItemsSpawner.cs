using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ItemPrefab;
    [SerializeField] private List<Transform> _spawnpoints = new List<Transform>();

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (var item in _spawnpoints)
        {
            Instantiate(_ItemPrefab, item.position, Quaternion.identity);
        }
    }
}
