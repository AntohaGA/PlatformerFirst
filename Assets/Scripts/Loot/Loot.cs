using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    public abstract void TakeMe(ITakerLoot taker);
}