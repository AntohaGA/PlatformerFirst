using UnityEngine;

[RequireComponent(typeof(CoinLooter))]
public class FinderLoot : MonoBehaviour
{
    private CoinLooter _coinLooter;

    private void Awake()
    {
        _coinLooter = GetComponent<CoinLooter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coinLooter.AddCoin(coin);
        }
    }
}