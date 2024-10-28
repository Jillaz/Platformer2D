using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    public bool IsJump { get; private set; }
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetButton(Jump))
        {
            IsJump = true;
        }
        else
        {
            IsJump = false;
        }
    }
}
