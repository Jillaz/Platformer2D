using UnityEngine;
using System;

public class EnemyPlayerDetector : MonoBehaviour
{
    public Transform PlayerTransform { get; private set; } = null;

    public event Action PlayerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CombatStats player))
        {
            PlayerTransform = player.transform;
            PlayerDetected?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerTransform = null;
        PlayerDetected?.Invoke();
    }
}
