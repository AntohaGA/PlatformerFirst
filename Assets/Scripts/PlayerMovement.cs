using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerMovement : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;

    public float CurrentDirection { get ; private set; }
    public bool IsJump { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        _inputReader.CheckInput();
    }

    public void Move()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
            CurrentDirection = _inputReader.Direction;
        }

        if (_groundDetector.IsGround)
        {
            IsJump = false;
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            IsJump = true;
        }
    }
}