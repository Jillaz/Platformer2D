using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public static int IsMoving = Animator.StringToHash(nameof(IsMoving));

    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _waitingTime = 1f;
    private Vector2 _direction = Vector2.right;
    private int _changeDirection = -1;
    private bool _isCanMove = true;

    private void Awake()
    {
        _animator.SetBool(IsMoving, _isCanMove);
    }

    private void Update()
    {
        if (_isCanMove)
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FallingZone _))
        {
            _isCanMove = false;
            _animator.SetBool(IsMoving, _isCanMove);
            StartCoroutine(StayAtPosition());
        }
    }

    private IEnumerator StayAtPosition()
    {
        var delay = new WaitForSeconds(_waitingTime);

        yield return delay;

        _direction *= _changeDirection;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _isCanMove = true;
        _animator.SetBool(IsMoving, _isCanMove);
    }
}
