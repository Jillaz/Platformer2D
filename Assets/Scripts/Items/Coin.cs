using UnityEngine;

public class Coin : MonoBehaviour
{
    [field: SerializeField] public int CoinCost { get; private set; } = 1;
}
