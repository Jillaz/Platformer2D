using UnityEngine;

public class EnemyModelRenderer : MonoBehaviour
{    
    [SerializeField] private Transform _viewModel;

    private float _lookRight = 0;
    private float _lookLeft = 180;

    public void TurnModelToRight()
    {
        _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _lookRight);
    }

    public void TurnModelToLeft()
    {
        _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _lookLeft);
    }    
}
