using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyModelRenderer _enemyRenderer;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private EnemyPlayerDetector _playerDetector;
    [SerializeField] private EnemyAttackRangeDetector _attackRangeDetector;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitingTime = 1f;
    [SerializeField] private float _attackDelay = 2f;
    private Vector2 _direction = Vector2.right;
    private Transform _destination;
    private bool _isCanMove = true;
    private bool _isInAttackRange = false;
    private bool _isPlayerInTartget = false;

    private void Start()
    {
        _enemyAnimator.SetMovingAnimation(_isCanMove);        
    }

    private void OnEnable()
    {
        _playerDetector.PlayerDetected += FollowPlayer;
        _attackRangeDetector.PlayerEnterAttackRange += StartAttack;
        _attackRangeDetector.PlayerLeaveAttackRange += StopAttack;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerDetected -= FollowPlayer;
        _attackRangeDetector.PlayerEnterAttackRange -= StartAttack;
        _attackRangeDetector.PlayerLeaveAttackRange -= StopAttack;
    }

    private void FixedUpdate()
    {
        if (_isCanMove)
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
            ChangeDirection();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlatformEdge fallingZone) && _isPlayerInTartget == false)
        {
            _destination = fallingZone.NextPatrolWaypoint;
            _isCanMove = false;
            _enemyAnimator.SetMovingAnimation(_isCanMove);
            StartCoroutine(StayAtPosition());
        }
    }

    private IEnumerator StayAtPosition()
    {
        var delay = new WaitForSeconds(_waitingTime);

        yield return delay;

        ChangeDirection();
        _isCanMove = true;
        _enemyAnimator.SetMovingAnimation(_isCanMove);
    }

    private void ChangeDirection()
    {
        if (_destination == null)
        {
            return;
        }

        if (transform.position.x > _destination.position.x)
        {
            _direction = Vector2.left;
        }

        if (transform.position.x < _destination.position.x)
        {
            _direction = Vector2.right;
        }

        _enemyRenderer.TurnOtherWay(_destination); 
    }

    private void FollowPlayer()
    {
        _isCanMove = true;
        _isPlayerInTartget = true;
        _destination = _playerDetector.PlayerTransform;
        _enemyAnimator.SetMovingAnimation(_isCanMove);

        if (_destination == null)
        {
            _isPlayerInTartget = false;
        }
    }

    private void StartAttack()
    {
        _isInAttackRange = true;
        _isCanMove = false;
        _enemyAnimator.SetMovingAnimation(_isCanMove);
        StartCoroutine(AttackPlayer());
    }

    private void StopAttack()
    {
        _isInAttackRange = false;
        _isCanMove = true;
        _enemyAnimator.SetMovingAnimation(_isCanMove);
    }

    private IEnumerator AttackPlayer()
    {
        var delay = new WaitForSeconds(_attackDelay);

        while (_isInAttackRange)
        {
            yield return delay;
            _enemyAnimator.Attack();            
        }
    }
}
