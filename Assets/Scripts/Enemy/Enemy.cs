using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(Follower))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(PlayerDetector))]
public class Enemy : MonoBehaviour
{
    private const float StartHealth = 100;

    private Mover _mover;
    private Patroller _patroller;
    private Flipper _flipper;
    private EnemyAnimator _animator;
    private Follower _follower;
    private PlayerDetector _playerDetector;

    private float _direction;
    private float _health;

    private enum State
    {
        Patrool,
        Follow,
        Attack
    }

    private State _state;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _patroller = GetComponent<Patroller>();
        _flipper = GetComponent<Flipper>();
        _animator = GetComponent<EnemyAnimator>();
        _follower = GetComponent<Follower>();
        _playerDetector = GetComponent<PlayerDetector>();

        _health = StartHealth;
        _playerDetector.CheckedPlayer += GoToPlayer;
        _playerDetector.LostPlayer += MoveByPoints;
    }

    public void TakeDamage(float damage)
    {
        _animator.HitAnimation();
        _health -= damage;
    }

    private float GetDirection()
    {
        switch (_state)
        {
            case State.Patrool:
                return _patroller.GetDirection();

            case State.Follow:
                return _follower.GetDirection();
        }

        return _patroller.GetDirection();
    }

    private void FixedUpdate()
    {
        _direction = GetDirection();
        _flipper.SetDirection(_direction);
        _mover.Move(_direction);
    }

    private void GoToPlayer(PlayerMovement playerMovement)
    {
        Debug.Log("Got to player");
        _state = State.Follow;
        _animator.RunAnimation();
    }

    private void MoveByPoints()
    {
        Debug.Log("MoveByPoints");
        _state = State.Patrool;
        _animator.RunAnimation();
    }

    private void Attack()
    {
        Debug.Log("Attack Player");
        _state = State.Attack;
        _animator.AttackAnimation();
    }
}