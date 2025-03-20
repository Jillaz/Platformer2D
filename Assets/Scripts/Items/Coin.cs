using UnityEngine;

public class Coin : Items
{
    [field: SerializeField] public int CoinCost { get; private set; } = 1;    
}