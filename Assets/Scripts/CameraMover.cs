using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _speed = 5f;
    private float _defaultCameraPositionOnZ;

    private void Start()
    {
        _defaultCameraPositionOnZ = transform.position.z;
    }

    private void LateUpdate()
    {
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y, _defaultCameraPositionOnZ);
        Vector3 endPosition = new Vector3(_cameraTarget.position.x, _cameraTarget.position.y, _defaultCameraPositionOnZ);        
        transform.position = Vector3.Lerp(startPosition, endPosition, _speed * Time.deltaTime);        
    }
}
