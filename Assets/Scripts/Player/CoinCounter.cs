using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private float _allPrice = 0;

    public void Add(float price)
    {
        _allPrice += price;
        Debug.Log(_allPrice);
    }
}