using System;
using UnityEngine;

[RequireComponent(typeof(LootLifter))]
public class Health : MonoBehaviour, IDamagable
{
    private LootLifter _sorter;

    public event Action TakedHit;

    public float Count { get; private set; } = 100;

    private void OnEnable()
    {
        _sorter = GetComponent<LootLifter>();
        _sorter.TakedAidKit += Add;
    }

    private void OnDisable()
    {
        _sorter.TakedAidKit -= Add;
    }

    public void TakeDamage(float damage)
    {
        if (Count > 0 && damage > 0)
        {
            Count -= damage;
            Debug.Log(Count);
            TakedHit?.Invoke();
        }
    }

    private void Add(AidKit aidKit)
    {
        Count += aidKit.CountHealth;
        Destroy(aidKit.gameObject);
        Debug.Log(Count);
    }
}