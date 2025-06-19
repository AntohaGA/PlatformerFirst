using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float StartHealth;

    private float _min = 0;

    public event Action<float, float> Changed;

    public float Max { get; private set; }
    public float Count { get; private set; }

    private void Awake()
    {
        Count = StartHealth;
        Max = StartHealth;
        Debug.Log(Count);
    }

    public void TakeDamage(float damage)
    {
        if (Count > _min && damage > 0)
        {
            Count = Mathf.Clamp(Count - damage, _min, Max);
            Changed?.Invoke(- damage, Max);
        }
    }

    public void Add(float countHealth)
    {
        Debug.Log("Add?" + countHealth);

        if (Count < Max && countHealth > 0)
        {
            Count = Mathf.Clamp(Count + countHealth, _min, Max);

            Debug.Log("Add!" + Count);

            Changed?.Invoke(countHealth, Max);
        }
    }
}