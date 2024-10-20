using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DeathZone _))
        {            
            transform.position = _startPosition.position;
        }
    }
}
