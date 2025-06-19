using System;
using UnityEngine;

public class LootSorter : MonoBehaviour, ITakerLoot
{
    public event Action<float> TakedCoin;
    public event Action<float> TakedAidKit;

    public void Take(Coin coin)
    {
        TakedCoin?.Invoke(coin.Price);
        Destroy(coin.gameObject);
    }

    public void Take(AidKit aid)
    {
        TakedAidKit?.Invoke(aid.CountHealth);
        Destroy(aid.gameObject);
    }
}