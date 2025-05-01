using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    private const string Fire1 = nameof(Fire1);
    private const string Fire2 = nameof(Fire2);
 
    [SerializeField] private CharacterAnimator _animator;

    public event Action AuraActivated;

    public float Direction { get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);
        _animator.PlayMovingAnimation(Direction);
        IsJump = Input.GetButton(Jump);

        if (Input.GetButton(Fire1))
        {
            _animator.PlayAttackAnimation();
        }

        if (Input.GetButton(Fire2))
        {
            AuraActivated?.Invoke();
        }
    }
}
