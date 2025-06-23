using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(FinderClosestEnemy))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _areaAbility;
    [SerializeField] private float _targetLayer;

    private Vector3 _centerAbility;
    private float _radiusAbility = 3f;
    private float _vampirismTime = 6f;
    private float _reloadTime = 4f;

    private Health _health;
    private FinderClosestEnemy _finderClosestEnemy;
    private Coroutine _vampirismCoroutine;
    private Coroutine _reloadCoroutine;
    private WaitForSeconds _reloadWait;

    private bool _isActive = false;
    private bool _isReload = false;

    public event Action<float, float> ChangedState;

    private void Start()
    {
        _health = GetComponent<Health>();
        _finderClosestEnemy = GetComponent<FinderClosestEnemy>();
        _reloadWait = new WaitForSeconds(_reloadTime);
    }

    public void On()
    {
        if (_isActive == false && _isReload == false)
        {
            if (_vampirismCoroutine != null)
                StopCoroutine(_vampirismCoroutine);

            _vampirismCoroutine = StartCoroutine(VampirismProcess());
        }
    }

    private void SwitchAreaAbility()
    {
        if (_areaAbility.enabled)
            _areaAbility.enabled = false;
        else
            _areaAbility.enabled = true;
    }

    private void ReloadAbility()
    {
        if (_reloadCoroutine != null)
            StopCoroutine(_reloadCoroutine);

        _reloadCoroutine = StartCoroutine(ReloadProcess());
    }

    private IEnumerator VampirismProcess()
    {
        float timerAbility = _vampirismTime;

        ChangedState?.Invoke(_vampirismTime, 0);
        SwitchAreaAbility();
        _isActive = true;

        while (timerAbility > 0)
        {
            timerAbility -= Time.deltaTime;

            if (_health.Count < _health.Max)
                OneBiteVampirism();

            yield return null;
        }

        SwitchAreaAbility();
        _isActive = false;
        ReloadAbility();
    }

    private IEnumerator ReloadProcess()
    {
        _isReload = true;
        ChangedState?.Invoke(_reloadTime, 1);

        yield return _reloadWait;

        _isReload = false;
    }

    private void OneBiteVampirism()
    {
        float speed = 0.1f;
        IDamagable damagable;

        _centerAbility = transform.position;
        _centerAbility.y += 1;

        Collider2D[] results = Physics2D.OverlapCircleAll(_centerAbility, _radiusAbility);
        damagable = _finderClosestEnemy.Get(results, _targetLayer);

        if (damagable != null)
            _health.Add(damagable.TakeDamage(speed));
    }
}