using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerMovement : MonoBehaviour
{
    public float CurrentDirection;
    public bool IsJump;

    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    public void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
            CurrentDirection = _inputReader.Direction;
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            IsJump = false;
        }
        else
        {
            IsJump = true;
        }

        if (_groundDetector.IsGround)
        {
            IsJump = false;
        }
        else
        {
            IsJump = true;
        }
    }
}