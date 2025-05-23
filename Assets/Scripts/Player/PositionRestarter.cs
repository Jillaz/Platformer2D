using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Health _characterHealth;

    private void OnEnable()
    {
        _characterHealth.Died += RestartPosition;
    }

    private void OnDisable()
    {
        _characterHealth.Died -= RestartPosition;
    }    

    private void RestartPosition()
    {
        transform.position = _startPosition.position;
        _characterHealth.Ressurect();
    }
}
