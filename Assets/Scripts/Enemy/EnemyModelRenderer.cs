using UnityEngine;

public class EnemyModelRenderer : MonoBehaviour
{
    [SerializeField] private Transform _viewModel;

    private float _turnRight = 0;
    private float _turnLeft = 180;

    public void TurnOtherWay(Transform target)
    {        
        if (transform.position.x > target.position.x)
        {
            _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _turnLeft);
        }

        if (transform.position.x < target.position.x)
        {
            _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _turnRight);
        }
    }
}
