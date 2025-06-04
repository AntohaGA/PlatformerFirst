using UnityEngine;

[RequireComponent(typeof(LootLifter))]
public class LootFinder : MonoBehaviour
{
    private LootLifter _lootSorter;

    private void Awake()
    {
        _lootSorter = GetComponent<LootLifter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
        {
            loot.Take(_lootSorter);
        }
    }
}