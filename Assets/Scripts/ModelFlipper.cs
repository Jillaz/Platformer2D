using UnityEngine;

public class ModelFlipper : MonoBehaviour
{
    [SerializeField] private Transform _viewModel;

    private float _lookRight = 0;
    private float _lookLeft = 180;

    public void FlipRotation(float moveDiretion)
    {
        if (moveDiretion > 0)
        {
            _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _lookRight);
        }
        else if (moveDiretion < 0)
        {
            _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _lookLeft);
        }
    }
}
