using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(CoinCounter))]
public class PlayerAction : MonoBehaviour
{
    private const float AttackDamage = 10;

    private Mover _mover;
    private InputReader _inputReader;
    private PlayerAnimator _playerAnimator;
    private Flipper _flipper;
    private GroundDetector _groundDetector;
    private Damager _damager;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _flipper = GetComponent<Flipper>();
        _damager = GetComponentInChildren<Damager>();
        _groundDetector = GetComponentInChildren<GroundDetector>();
    }

    private void OnEnable()
    {
        _inputReader.MovePressed += Move;
        _inputReader.JumpPressed += Jump;
        _inputReader.AttackPressed += Attack;
        _groundDetector.Landed += Land;
        _groundDetector.Falling += Fall;
    }

    private void OnDisable()
    {
        _inputReader.MovePressed -= Move;
        _inputReader.JumpPressed -= Jump;
        _inputReader.AttackPressed -= Attack;
        _groundDetector.Landed -= Land;
        _groundDetector.Falling -= Fall;
    }

    private void Move(float direction)
    {
        _flipper.SetDirection(direction);
        _mover.Move(direction);
        _playerAnimator.Move(direction);
    }

    private void Jump()
    {
        if (_groundDetector.InAir == false)
        {
            _mover.Jump();
            _playerAnimator.JumpAnimation();
        }
    }

    private void Fall()
    {
        _playerAnimator.FallAnimation();
    }

    private void Land()
    {
        _playerAnimator.LandAnimation();
    }

    private void Attack()
    {
        _damager.Hit(AttackDamage);
        _playerAnimator.AttackAnimation();
    }
}