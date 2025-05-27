using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(Follower))]
public class Enemy : MonoBehaviour, IDamagable
{
    private const float StartHealth = 100;

    private Mover _mover;
    private Patroller _patroller;
    private Flipper _flipper;
    private EnemyAnimator _animator;
    private Follower _follower;
    private EnemyAttacker _enemyAttacker;

    private PlayerDetector _playerDetector;
    private AttackDetector _attackDetector;

    private float _direction;
    private float _health;

    private Enum _state = new EnemyState();

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _patroller = GetComponent<Patroller>();
        _flipper = GetComponent<Flipper>();
        _animator = GetComponent<EnemyAnimator>();
        _follower = GetComponent<Follower>();
        _enemyAttacker = GetComponentInChildren<EnemyAttacker>();
        _playerDetector = GetComponentInChildren<PlayerDetector>();
        _attackDetector = GetComponentInChildren<AttackDetector>();
        _health = StartHealth;
    }

    private void OnEnable()
    {
        _playerDetector.CheckedPlayer += GoToPlayer;
        _playerDetector.LostPlayer += MoveByPoints;
        _attackDetector.AttackPlayer += Attack;
        _attackDetector.LostAttackPlayer += StopAttack;
    }

    private void OnDisable()
    {
        _playerDetector.CheckedPlayer -= GoToPlayer;
        _playerDetector.LostPlayer -= MoveByPoints;
        _attackDetector.AttackPlayer -= Attack;
        _attackDetector.LostAttackPlayer -= StopAttack;
    }

    public void TakeDamage(float damage)
    {
        _animator.HitAnimation();
        _health -= damage;
        Debug.Log(_health + " - health");
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
        _enemyAttacker.Attack();
        _animator.AttackAnimation();
    }

    private void StopAttack()
    {
        _state = EnemyState.Patrool;
        _animator.StopAttackAnimation();
        _enemyAttacker.StopAttack();
    }
}