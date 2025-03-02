using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private CombatStats _combatStats;

    private void OnEnable()
    {
        _combatStats.SuddenDeath += RestartPosition;
    }

    private void OnDisable()
    {
        _combatStats.SuddenDeath -= RestartPosition;
    }    

    private void RestartPosition()
    {
        transform.position = _startPosition.position;
    }
}
