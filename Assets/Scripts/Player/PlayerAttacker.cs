using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{    
    [SerializeField] private Collider2D _hitZone;

    public void Attack()
    {
        _hitZone.enabled = true;
    }

    public void StopAttack()
    {
        _hitZone.enabled = false;
    }
}
