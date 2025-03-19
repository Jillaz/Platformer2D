using UnityEngine;
using System;

public class EnemyPlayerDetector : MonoBehaviour
{
    public event Action<Transform> PlayerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterStats player))
        {            
            PlayerDetected?.Invoke(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        PlayerDetected?.Invoke(null);
    }
}
