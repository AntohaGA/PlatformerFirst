using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    public abstract void Take(ITakerLoot taker);
}