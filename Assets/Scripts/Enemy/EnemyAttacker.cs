using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Damager))]
public class EnemyAttacker : MonoBehaviour
{
    private const float AttackDelay = 0.667f;
    private const float Damage = 10;

    private IEnumerator _delayAttackCoroutine;
    private WaitForSeconds _delayAttackTime;
    private Damager _hitter;
    private bool _isAttack = false;

    private void Awake()
    {
        _hitter = GetComponent<Damager>();
        _delayAttackTime = new WaitForSeconds(AttackDelay);
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

            _hitter.Hit(Damage);
        }
    }
}