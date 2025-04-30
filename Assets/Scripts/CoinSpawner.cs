using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _coinSpots;

    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        for (int i = 0; i < _coinSpots.Length; i++)
        {
            SpawnCoin(_coinSpots[i].transform);
        }
    }

    private void SpawnCoin(Transform transformCoin)
    {
        Coin newCoin;
        newCoin = Instantiate(_coinPrefab, transformCoin.position, Quaternion.identity);
        newCoin.TakedByPlayer += DestroyCoin;
    }

    private void DestroyCoin(Coin coin)
    {
        _coinPrefab.TakedByPlayer -= DestroyCoin;
        Destroy(coin.gameObject);
    }
}