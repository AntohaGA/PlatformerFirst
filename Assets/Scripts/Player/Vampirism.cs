using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _areaVampirism;
    [SerializeField] private float _layerForVamp;

    private Vector3 _centerAbility;
    private float _radiusAbility = 3f;

    private float _vampirismTime = 6f;
    private float _reloadTime = 4f;

    private Health _health;

    private Coroutine _vampirismCoroutine;
    private Coroutine _reloadCoroutine;
    private WaitForSeconds _reloadWait;

    private bool _isActive;
    private bool _isReload;

    public event Action<float, float, float> ChangedStatusVampirism;

    private void Start()
    {
        _health = GetComponent<Health>();
        _isActive = false;
        _isReload = false;
        _reloadWait = new WaitForSeconds(_reloadTime);
    }

    private void OnDrawGizmos()
    {
        _centerAbility = transform.position;
        _centerAbility.y += 1;

        Gizmos.DrawWireSphere(_centerAbility, _radiusAbility);
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

        Collider2D[] results = Physics2D.OverlapCircleAll(_centerAbility, _radiusAbility);

        damagable = GetClosestEnemy(results);

        if (damagable != null)
            _health.Add(damagable.TakeDamage(speed));

    }

    private IDamagable GetClosestEnemy(Collider2D[] results)
    {
        float distant = 0;
        IDamagable closestEnemy = null;

        foreach (Collider2D collder in results)
        {
            if (Vector2.Distance(collder.transform.position, transform.position) > distant)
            {
                if (collder.TryGetComponent(out IDamagable damagable)
                                             && collder.gameObject.layer == _layerForVamp && collder.isTrigger == false)
                {
                    closestEnemy = damagable;
                }
            }
        }

        return closestEnemy;
    }
}