using UnityEngine;

[RequireComponent(typeof(CoinCounter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(LootChecker))]
public class Bag : MonoBehaviour, ITakerLoot
{
    private CoinCounter _coins;
    private Health _healthHero;

    private void Awake()
    {
        _coins = GetComponent<CoinCounter>();
        _healthHero = GetComponent<Health>();
    }

    public void Take(Coin coin)
    {
        _coins.AddCoin(coin);
        Destroy(coin.gameObject);
    }

    public void Take(AidKit health)
    {
        _healthHero.AddHealth(health);
        Destroy(health.gameObject);
    }
}