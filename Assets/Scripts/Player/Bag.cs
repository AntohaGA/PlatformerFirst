using UnityEngine;

[RequireComponent(typeof(CoinCounter))]
[RequireComponent(typeof(LootSorter))]
[RequireComponent(typeof(Health))]
public class Bag : MonoBehaviour
{
    private CoinCounter _coins;
    private LootSorter  _lootSorter;
    private Health _health;

    private void Awake()
    {
        _coins = GetComponent<CoinCounter>();
        _lootSorter = GetComponent<LootSorter>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _lootSorter.TakedCoin += AddCoin;
        _lootSorter.TakedAidKit += AddAidkit;
    }

    private void OnDisable()
    {
        _lootSorter.TakedCoin -= AddCoin;
        _lootSorter.TakedAidKit -= AddAidkit;
    }

    public void AddCoin(float price)
    {
        _coins.Add(price);
    }

    public void AddAidkit(float countHealth)
    {
        _health.Add(countHealth);
    }
}