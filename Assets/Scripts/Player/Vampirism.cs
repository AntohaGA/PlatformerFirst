using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(FinderClosestEnemy))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _areaVampirism;
    [SerializeField] private float _layerForVamp;

    private Vector3 _centerAbility;
    private float _radiusAbility = 3f;
    private float _vampirismTime = 6f;
    private float _reloadTime = 4f;

    private Health _health;
    private FinderClosestEnemy _finderClosestEnemy;
    private Coroutine _vampirismCoroutine;
    private Coroutine _reloadCoroutine;
    private WaitForSeconds _reloadWait;

    private bool _isActive;
    private bool _isReload;

    public event Action<float, float, float> ChangedStatusVampirism;

    private void Start()
    {
        _health = GetComponent<Health>();
        _finderClosestEnemy = GetComponent<FinderClosestEnemy>();
        _isActive = false;
        _isReload = false;
        _reloadWait = new WaitForSeconds(_reloadTime);
    }

    private void SwitchAreaAbility()
    {
        if (_areaVampirism.enabled)
            _areaVampirism.enabled = false;
        else
            _areaVampirism.enabled = true;
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

    private void ReloadAbility()
    {
        if (_reloadCoroutine != null)
            StopCoroutine(_reloadCoroutine);

        _reloadCoroutine = StartCoroutine(ReloadProcess());
    }

    private IEnumerator VampirismProcess()
    {
        float timerAbility = _vampirismTime;

        ChangedStatusVampirism?.Invoke(_vampirismTime, 1, 0);
        SwitchAreaAbility();
        _isActive = true;

        while (timerAbility > 0)
        {
            timerAbility -= Time.deltaTime;

            if (_health.Count < _health.Max)
                OneShotVampirism();

            yield return null;
        }

        SwitchAreaAbility();
        _isActive = false;
        ReloadAbility();
    }

    private IEnumerator ReloadProcess()
    {
        _isReload = true;
        ChangedStatusVampirism?.Invoke(_reloadTime, 0, 1);

        yield return _reloadWait;

        _isReload = false;
    }

    private void OneShotVampirism()
    {
        float speed = 0.1f;
        IDamagable damagable;

        _centerAbility = transform.position;
        _centerAbility.y += 1;

        Collider2D[] results = Physics2D.OverlapCircleAll(_centerAbility, _radiusAbility);
        damagable = _finderClosestEnemy.GetClosestEnemy(results, _layerForVamp);

        if (damagable != null)
            _health.Add(damagable.TakeDamage(speed));
    }
}