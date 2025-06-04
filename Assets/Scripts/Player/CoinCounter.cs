using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private float _allPrice = 0;

    public void Add(Coin coin)
    {
        _allPrice += coin.Price;
        Debug.Log(_allPrice);
    }
}