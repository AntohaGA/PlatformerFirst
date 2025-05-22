using UnityEngine;

public class HealthHero : MonoBehaviour
{
    public float HealthPlayer { get; private set; } = 100;

    public void AddHealth(Health health)
    {
        HealthPlayer += health.CountHealth;
        Debug.Log(HealthPlayer);
        health.Take();
    }

    public void HitHero(float damage)
    {
        if(HealthPlayer > 0 && damage > 0)
            HealthPlayer -= damage;
    }
}