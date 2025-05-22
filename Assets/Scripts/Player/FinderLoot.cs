using UnityEngine;

[RequireComponent(typeof(CoinCounter))]
[RequireComponent(typeof(HealthHero))]
public class FinderLoot : MonoBehaviour
{
    private CoinCounter _coinCounter;
    private HealthHero _healthHero;

    private void Awake()
    {
        _coinCounter = GetComponent<CoinCounter>();
        _healthHero = GetComponent<HealthHero>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coinCounter.AddCoin(coin);
        }

        if (collision.TryGetComponent(out Health health))
        {
            _healthHero.AddHealth(health);    
        }
    }
}