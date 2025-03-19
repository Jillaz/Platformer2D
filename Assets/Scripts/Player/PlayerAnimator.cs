using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    public static int IsRunning = Animator.StringToHash(nameof(IsRunning));

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private Animator _animator;

    private void OnEnable()
    {
        _characterStats.HitRecived += HitRecived;
    }

    private void OnDisable()
    {
        _characterStats.HitRecived -= HitRecived;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
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