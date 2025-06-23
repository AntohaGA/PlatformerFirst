using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _startHealth;

    private float _min = 0;

    public event Action<float, float> Changed;

    public float Max { get; private set; }
    public float Count { get; private set; }

    private void Awake()
    {
        Count = _startHealth;
        Max = _startHealth;
    }

    public float TakeDamage(float damage)
    {
        float lossedHealth = 0;

        if (Count > _min && damage > 0)
        {
            if (Count >= damage)
                lossedHealth = damage;
            else
                lossedHealth = Count;

            Count = Mathf.Clamp(Count - damage, _min, Max);
            Changed?.Invoke(-lossedHealth, Count / Max);
        }

        return lossedHealth;
    }

    public void Add(float countHealth)
    {
        if (Count < Max && countHealth > 0)
        {
            Count = Mathf.Clamp(Count + countHealth, _min, Max);
            Changed?.Invoke(countHealth, Count / Max);
        }
    }
}