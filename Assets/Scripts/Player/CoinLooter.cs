using UnityEngine;

public class CoinLooter : MonoBehaviour
{
    private int _coinCount = 0;

    public void AddCoin(Coin coin)
    {
        _coinCount++;
        Debug.Log(_coinCount);
        coin.Take();
    }
}
