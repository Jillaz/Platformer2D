using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static int IsRunning = Animator.StringToHash(nameof(IsRunning));

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CombatStats _combatStats;
    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private void OnEnable()
    {
        _combatStats.HitRecived += HitRecived;
    }

    private void OnDisable()
    {
        _combatStats.HitRecived -= HitRecived;
    }

    private void Update()
    {
        _animator.SetBool(IsRunning, _playerInput.Direction != 0);
        Attack();
    }

    private void HitRecived()
    {
        _animator.Play(_hitted.name);
    }

    private void Attack()
    {
        if (_playerInput.IsAttack)
        {
            _animator.Play(_attack.name);
        }
    }
}