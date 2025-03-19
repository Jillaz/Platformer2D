using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private CharacterStats _characterStats;

    private void OnEnable()
    {
        _characterStats.CharacterDied += RestartPosition;
    }

    private void OnDisable()
    {
        _characterStats.CharacterDied -= RestartPosition;
    }    

    private void RestartPosition()
    {
        transform.position = _startPosition.position;
        _characterStats.Ressurect();
    }
}
