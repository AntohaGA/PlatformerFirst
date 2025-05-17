using UnityEngine;

[RequireComponent(typeof(CoinLooter))]
[RequireComponent(typeof(HealthLooter))]
public class FinderLoot : MonoBehaviour
{
    private CoinLooter _coinLooter;
    private HealthLooter _healthLooter;

    private void Awake()
    {
        _coinLooter = GetComponent<CoinLooter>();
        _healthLooter = GetComponent<HealthLooter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coinLooter.AddCoin(coin);
        }

        if (collision.TryGetComponent(out Health health))
        {
            _healthLooter.AddHealth(health);    
        }
    }
}