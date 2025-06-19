using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Damager))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerAction : MonoBehaviour
{
    private Mover _mover;
    private InputReader _inputReader;
    private PlayerAnimator _playerAnimator;
    private Flipper _flipper;
    private GroundDetector _groundDetector;
    private Damager _damager;
    private Health _health;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _flipper = GetComponent<Flipper>();
        _damager = GetComponent<Damager>();
        _health = GetComponent<Health>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _inputReader.MovePressed += Move;
        _inputReader.JumpPressed += Jump;
        _inputReader.AttackPressed += Attack;
        _groundDetector.Landed += Land;
        _groundDetector.Falling += Fall;
        _health.Changed += HealthChanged;
    }

    private void OnDisable()
    {
        _inputReader.MovePressed -= Move;
        _inputReader.JumpPressed -= Jump;
        _inputReader.AttackPressed -= Attack;
        _groundDetector.Landed -= Land;
        _groundDetector.Falling -= Fall;
        _health.Changed -= HealthChanged;    
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
        _damager.Hit();
        _playerAnimator.AttackAnimation();
    }

    private void HealthChanged(float change, float MaxValue)
    {
        if (change < 0)
        {
            _playerAnimator.TakeHitAnumation();
        }
    }
}