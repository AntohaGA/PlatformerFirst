using UnityEngine;

public class SpawnerLoot : MonoBehaviour
{
    [SerializeField] private Transform[] _spotsSpawn;
    [SerializeField] private Loot _lootPrefab;

    private void Start()
    {
        for (int i = 0; i < _spotsSpawn.Length; i++)
        {
            SpawnCoin(_spotsSpawn[i].transform);
        }
    }

    private void SpawnCoin(Transform spawnSpoot)
    {
        Instantiate(_lootPrefab, spawnSpoot.position, Quaternion.identity);
    }
}