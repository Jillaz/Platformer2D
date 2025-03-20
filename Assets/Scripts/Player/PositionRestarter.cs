using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private CharacterHealth _characterHealth;

    private void OnEnable()
    {
        _characterHealth.CharacterDied += RestartPosition;
    }

    private void OnDisable()
    {
        _characterHealth.CharacterDied -= RestartPosition;
    }    

    private void RestartPosition()
    {
        transform.position = _startPosition.position;
        _characterHealth.Ressurect();
    }
}
