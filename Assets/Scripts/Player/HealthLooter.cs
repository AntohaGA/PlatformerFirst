using UnityEngine;

public class HealthLooter : MonoBehaviour
{
    private float _healthPlayer = 10;

    public void AddHealth(Health health)
    {
        _healthPlayer += health.CountHealth;
        Debug.Log(_healthPlayer);
        health.Take();
    }
}