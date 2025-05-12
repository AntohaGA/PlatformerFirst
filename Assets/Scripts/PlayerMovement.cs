using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerMovement : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();

        _inputReader.MovePressed += Move;
        _inputReader.JumpPressed += Jump;
    }

    public void Move(float direction)
    {
        _mover.Move(direction);
    }

    public void Jump()
    {
        if (_groundDetector.InAir == false)
            _mover.Jump();
    }
}