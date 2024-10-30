using UnityEngine;

public class PlayerModelRenderer : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _viewModel;
    private float _lookRight = 0;
    private float _lookLeft = 180;
    
    private void Update()
    {
        FlipRotation();
    }

    private void FlipRotation()
    {
        if (_playerInput.Direction > 0)
        {
            _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _lookRight);
        }

        if (_playerInput.Direction < 0)
        {
            _viewModel.eulerAngles = new Vector2(_viewModel.rotation.x, _lookLeft);
        }
    }
}
