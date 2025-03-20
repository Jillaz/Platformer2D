using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    public static int IsRunning = Animator.StringToHash(nameof(IsRunning));

    [SerializeField] private CharacterHealth _characterHealth;
    [SerializeField] private AnimationClip _hitted;
    [SerializeField] private AnimationClip _attack;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _characterHealth.HitRecived += HitRecived;
    }

    private void OnDisable()
    {
        _characterHealth.HitRecived -= HitRecived;
    }

    public void Attack()
    {
        _animator.Play(_attack.name);
    }

    public void Move(float direction)
    {
        _animator.SetBool(IsRunning, direction != 0);
    }

    private void HitRecived()
    {
        _animator.Play(_hitted.name);
    }
}