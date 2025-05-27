using UnityEngine;

public class LootChecker : MonoBehaviour
{
    private Bag bag;

    private void Awake()
    {
        bag = GetComponent<Bag>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
            loot.TakeMe(bag);
    }
}