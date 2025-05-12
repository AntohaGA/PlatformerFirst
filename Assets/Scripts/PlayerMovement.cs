using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerMovement : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;

    private bool OnGround;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();

        _inputReader.MovePressed += Move;
        _inputReader.JumpPressed += Jump;
        _groundDetector.Landed += SetPlayerOnGround;
        _groundDetector.Jumped += SetPlayerOnAir;
    }

    public void Move(float direction)
    {
        _mover.Move(direction);
    }

    public void Jump()
    {
        if (OnGround)
            _mover.Jump();
    }

    private void SetPlayerOnGround()
    {
        OnGround = true;
    }

    private void SetPlayerOnAir()
    {
        OnGround = false;
    }
}