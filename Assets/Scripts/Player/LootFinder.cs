using UnityEngine;

[RequireComponent(typeof(LootSorter))]
public class LootFinder : MonoBehaviour
{
    private LootSorter _lootSorter;

    private void Awake()
    {
        _lootSorter = GetComponent<LootSorter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
        {
            loot.Take(_lootSorter);
        }
    }
}