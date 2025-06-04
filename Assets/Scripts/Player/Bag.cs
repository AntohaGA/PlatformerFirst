using UnityEngine;

[RequireComponent(typeof(CoinCounter))]
[RequireComponent(typeof(LootLifter))]
public class Bag : MonoBehaviour
{
    private CoinCounter _coins;
    private LootLifter  _sorter;

    private void Awake()
    {
        _coins = GetComponent<CoinCounter>();
        _sorter = GetComponent<LootLifter>();
    }

    private void OnEnable()
    {
        _sorter.TakedCoin += AddCoin;
    }

    private void OnDisable()
    {
        _sorter.TakedCoin -= AddCoin;
    }

    public void AddCoin(Coin coin)
    {
        _coins.Add(coin);
        Destroy(coin.gameObject);
    }
}