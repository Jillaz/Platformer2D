using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyPlayerDetector _enemyPlayerDetector;
    [SerializeField] private EnemyAttackRangeDetector _enemyAttackRangeDetector;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private float _waitingTime = 1;
    [SerializeField] private float _attackDelay = 2f;

    private Transform _destination;
    private bool _isCanMove = true;
    private bool _isPlayerInTarget = false;
    private bool _isPlayerInAttackRange = false;

    private void OnEnable()
    {
        _enemyPlayerDetector.PlayerDetected += FollowPlayer;
        _enemyAttackRangeDetector.PlayerEnteredAttackRange += StartAttack;
        _enemyAttackRangeDetector.PlayerLeftAttackRange += StopAttack;
    }

    private void OnDisable()
    {
        _enemyPlayerDetector.PlayerDetected -= FollowPlayer;
        _enemyAttackRangeDetector.PlayerEnteredAttackRange -= StartAttack;
        _enemyAttackRangeDetector.PlayerLeftAttackRange -= StopAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlatformEdge platformEdge) && _isPlayerInTarget == false)
        {
            _destination = platformEdge.NextPatrolWaypoint;
            _isCanMove = false;
            _enemyMover.IsCanMove(_isCanMove);
            _enemyMover.SetDestination(_destination);
            StartCoroutine(StayAtPosition());
        }
    }

    private IEnumerator StayAtPosition()
    {
        var delay = new WaitForSeconds(_waitingTime);

        yield return delay;

        _isCanMove = true;
        _enemyMover.IsCanMove(_isCanMove);
    }

    private void FollowPlayer(Transform target)
    {
        _destination = target;

        if (_destination == null)
        {
            _isPlayerInTarget = false;
        }
        else
        {
            _isPlayerInTarget = true;
        }

        _enemyMover.SetDestination(_destination);
    }

    private void StartAttack()
    {
        _isPlayerInAttackRange = true;
        _isCanMove = false;
        _enemyMover.IsCanMove(_isCanMove);
        StartCoroutine(AttackPlayer());
    }

    private void StopAttack()
    {
        _isPlayerInAttackRange = false;
        _isCanMove = true;
        _enemyMover.IsCanMove(_isCanMove);
    }

    private IEnumerator AttackPlayer()
    {
        var delay = new WaitForSeconds(_attackDelay);

        while (_isPlayerInAttackRange)
        {
            yield return delay;
            _animator.PlayAttackAnimation();
        }
    }
}
