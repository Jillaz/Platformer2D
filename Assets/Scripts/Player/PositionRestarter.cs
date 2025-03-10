using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private CombatStats _combatStats;

    private void OnEnable()
    {
        _combatStats.CharacterDied += RestartPosition;
    }

    private void OnDisable()
    {
        _combatStats.CharacterDied -= RestartPosition;
    }    

    private void RestartPosition()
    {
        transform.position = _startPosition.position;
    }
}
