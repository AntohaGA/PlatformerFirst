using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
public class PlayerMovement : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private PlayerAnimator _playerAnimator;
    private Flipper _flipper;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _flipper = GetComponent<Flipper>();

        _inputReader.MovePressed += Move;
        _inputReader.JumpPressed += Jump;
        _groundDetector.Landed += Land;
        _groundDetector.Falling += Fall;
    }

    private void OnDestroy()
    {
        _inputReader.MovePressed -= Move;
        _inputReader.JumpPressed -= Jump;
        _groundDetector.Landed -= Land;
        _groundDetector.Falling -= Fall;
    }
    public void Fall()
    {
        _playerAnimator.JumpAnimation();
    }

    public void Move(float direction)
    {
        _flipper.SetDirection(direction);
        _mover.Move(direction);
        _playerAnimator.Move(direction);
    }

    public void Jump()
    {
        if (_groundDetector.InAir == false)
        {
            _mover.Jump();
            _playerAnimator.JumpAnimation();
        }
    }

    public void Land()
    {
        _playerAnimator.LandAnimation();
    }
}