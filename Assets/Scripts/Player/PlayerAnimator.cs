using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static int IsRunning = Animator.StringToHash(nameof(IsRunning));

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInput _playerInput;

    private void Update()
    {
        _animator.SetBool(IsRunning, _playerInput.Direction != 0);
    }
}