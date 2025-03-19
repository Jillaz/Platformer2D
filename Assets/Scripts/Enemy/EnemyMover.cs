using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private ModelFlipper _modelFlipper;
    [SerializeField] private CharacterStats _movementSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.right;
    private Transform _destination;
    private bool _isCanMove = true;

    public void SetDestination(Transform destination)
    {
        _destination = destination;
    }

    public void IsCanMove(bool isCanMove)
    {
        _isCanMove = isCanMove;
        _enemyAnimator.SetMovingAnimation(isCanMove);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyAnimator.SetMovingAnimation(_isCanMove);
    }

    private void FixedUpdate()
    {
        if (_isCanMove)
        {
            _rigidbody.velocity = new Vector2(_direction.x * _movementSpeed.MovementSpeed, _rigidbody.velocity.y);
            ChangeDirection();
        }
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

        _modelFlipper.FlipRotation(_direction.x);
    }   
}
