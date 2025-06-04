using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(Damager))]
public class EnemyAttacker : MonoBehaviour
{
    private const float AttackDelay = 0.667f;
    private const float Damage = 10;

    private IEnumerator _delayAttackCoroutine;
    private WaitForSeconds _delayAttackTime;
    private Damager _damager;
    private PlayerDetector _playerDetector;
    private bool _isAttack = false;

    private void Awake()
    {
        _damager = GetComponent<Damager>();
        _playerDetector = GetComponent<PlayerDetector>();
        _delayAttackTime = new WaitForSeconds(AttackDelay);
    }

    private void OnEnable()
    {
        _playerDetector.AttackPlayer += Attack;
        _playerDetector.LostAttackPlayer += StopAttack;
    }

    private void OnDisable()
    {
        _playerDetector.AttackPlayer -= Attack;
        _playerDetector.LostAttackPlayer -= StopAttack;
    }

    public void Attack()
    {
        StopAttack();
        _delayAttackCoroutine = DelayAttack();
        _isAttack = true;
        StartCoroutine(_delayAttackCoroutine);
    }

    public void StopAttack()
    {
        if (_delayAttackCoroutine != null)
            StopCoroutine(_delayAttackCoroutine);

        _isAttack = false;
    }

    private IEnumerator DelayAttack()
    {
        while (_isAttack)
        {
            yield return _delayAttackTime;

            _damager.Hit(Damage);
        }
    }
}