using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    private const string Fire1 = nameof(Fire1);

    public bool IsJump { get; private set; }
    public bool IsAttack { get; private set; }
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

        if (Input.GetButton(Fire1))
        {
            IsAttack = true;
        }
        else
        {
            IsAttack = false;
        }
    }
}
