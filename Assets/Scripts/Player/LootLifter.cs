using System;
using UnityEngine;

public class LootLifter : MonoBehaviour, ITakerLoot
{
    public event Action<Coin> TakedCoin;
    public event Action<AidKit> TakedAidKit;

    public void Take(Coin coin)
    {
        TakedCoin?.Invoke(coin);
    }

    public void Take(AidKit aid)
    {
        TakedAidKit?.Invoke(aid);
    }
}