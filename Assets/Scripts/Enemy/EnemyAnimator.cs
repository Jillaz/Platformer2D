using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public static int IsMoving = Animator.StringToHash(nameof(IsMoving));

    [SerializeField] private Animator _animator;

    public void SetMovingAnimation(bool isCanMove)
    {
        _animator.SetBool(IsMoving, isCanMove);
    }
}
