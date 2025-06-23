using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(Follower))]
[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;
    private Patroller _patroller;
    private Flipper _flipper;
    private EnemyAnimator _animator;
    private Follower _follower;
    private PlayerDetector _playerDetector;
    private Health _health;

    private float _direction;

    private Enum _state = new EnemyState();

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _patroller = GetComponent<Patroller>();
        _flipper = GetComponent<Flipper>();
        _animator = GetComponent<EnemyAnimator>();
        _follower = GetComponent<Follower>();
        _playerDetector = GetComponent<PlayerDetector>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _playerDetector.CheckedPlayer += GoToPlayer;
        _playerDetector.LostPlayer += MoveByPoints;
        _playerDetector.AttackPlayer += Attack;
        _playerDetector.LostAttackPlayer += StopAttack;
        _health.Changed += TakeDamage;
    }

    private void OnDisable()
    {
        _playerDetector.CheckedPlayer -= GoToPlayer;
        _playerDetector.LostPlayer -= MoveByPoints;
        _playerDetector.AttackPlayer += Attack;
        _playerDetector.LostAttackPlayer += StopAttack;
        _health.Changed -= TakeDamage;
    }

    private float GetDirection()
    {
        switch (_state)
        {
            case EnemyState.Patrool:
                return _patroller.GetDirection();

            case EnemyState.Follow:
                return _follower.GetDirection();

            case EnemyState.Attack:
                return transform.right.x;
        }

        return _patroller.GetDirection();
    }

    private void FixedUpdate()
    {
        _direction = GetDirection();
        _flipper.SetDirection(_direction);

        if(_state.Equals(EnemyState.Attack))   
            _mover.Move(0);
        else
            _mover.Move(_direction);
    }

    private void GoToPlayer(Transform player)
    {
        _state = EnemyState.Follow;
        _animator.RunAnimation();
    }

    private void MoveByPoints()
    {
        _state = EnemyState.Patrool;
        _animator.RunAnimation();
    }

    private void Attack()
    {
        _state = EnemyState.Attack;
        _animator.AttackAnimation();
    }

    private void StopAttack()
    {
        _state = EnemyState.Follow;
        _animator.StopAttackAnimation();
    }

    private void TakeDamage(float change,float percentValue)
    {
        _animator.HitAnimation();
    }
}