using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        Health.Changed -= OnChanged;
    }

    public abstract void OnChanged(float newValue, float maxValue);
}