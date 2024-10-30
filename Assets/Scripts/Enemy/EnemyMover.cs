using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitingTime = 1f;
    [SerializeField] EnemyModelRenderer _enemyRenderer;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    private Vector2 _direction = Vector2.right;
    private int _directionReverce = -1;
    private bool _isCanMove = true;

    private void Start()
    {
        _enemyAnimator.SetMovingAnimation(_isCanMove);
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
            _enemyAnimator.SetMovingAnimation(_isCanMove);
            StartCoroutine(StayAtPosition());
        }
    }

    private IEnumerator StayAtPosition()
    {
        var delay = new WaitForSeconds(_waitingTime);

        yield return delay;

        _direction *= _directionReverce;
        RotateModel();
        _isCanMove = true;
        _enemyAnimator.SetMovingAnimation(_isCanMove);
    }

    private void RotateModel()
    {
        if (_direction.x > 0)
        {
            _enemyRenderer.TurnModelToRight();
        }
        else
        {
            _enemyRenderer.TurnModelToLeft();
        }
    }
}
