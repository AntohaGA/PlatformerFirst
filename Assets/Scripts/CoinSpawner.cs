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
        Instantiate(_coinPrefab, transformCoin.position, Quaternion.identity);
    }
}