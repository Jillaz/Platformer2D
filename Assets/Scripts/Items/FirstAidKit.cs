using UnityEngine;

public class FirstAidKit : Items
{
    [field: SerializeField] public int HealthAmount { get; private set; } = 50;
}
