using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(FinderLoot))]
[RequireComponent(typeof(HealthHero))]
[RequireComponent(typeof(CoinCounter))]
public class PlayerMovement : MonoBehaviour, IDamagable
{
    private const float AttackDamage = 10;

    private Mover _mover;
    private InputReader _inputReader;
    private PlayerAnimator _playerAnimator;
    private Flipper _flipper;
    private HealthHero _healthHero;
    private GroundDetector _groundDetector;
    private Damager _damager;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _flipper = GetComponent<Flipper>();
        _healthHero = GetComponent<HealthHero>();
        _damager = GetComponentInChildren<Damager>();
        _groundDetector = GetComponentInChildren<GroundDetector>();

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

    public void TakeDamage(float damage)
    {
        _playerAnimator.TakeHitAnumation();
        _healthHero.HitHero(damage);
        Debug.Log(_healthHero.HealthPlayer + " - health");
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