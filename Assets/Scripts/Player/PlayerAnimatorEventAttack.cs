using UnityEngine;

public class PlayerAnimatorEventAttack : MonoBehaviour
{    
    [SerializeField] private Collider2D _hitZone;

    public void StartAttack()
    {
        _hitZone.enabled = true;
    }

    public void StopAttack()
    {
        _hitZone.enabled = false;
    }
}
