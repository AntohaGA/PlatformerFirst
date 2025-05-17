using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Attacker))]
public class PlayerMovement : MonoBehaviour
{
    private const float AttackDamage = 10;

    private Vector2 offsetAttack = new Vector2(0.9f, 0.8f);

    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private PlayerAnimator _playerAnimator;
    private Flipper _flipper;
    private Attacker _attacker;

    private float _damage;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _flipper = GetComponent<Flipper>();
        _attacker = GetComponent<Attacker>();

        _damage = AttackDamage;

        _inputReader.MovePressed += Move;
        _inputReader.JumpPressed += Jump;
        _inputReader.AttackPressed += Attack;
        _groundDetector.Landed += Land;
        _groundDetector.Falling += Fall;
    }

    private void OnDestroy()
    {
        _inputReader.MovePressed -= Move;
        _inputReader.JumpPressed -= Jump;
        _inputReader.AttackPressed -= Attack;
        _groundDetector.Landed -= Land;
        _groundDetector.Falling -= Fall;
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

    public void Fall()
    {
        _playerAnimator.FallAnimation();
    }

    public void Land()
    {
        _playerAnimator.LandAnimation();
    }

    public void Attack()
    {
        _playerAnimator.AttackAnimation();
        _attacker.Hit(_damage, offsetAttack);
    }
}