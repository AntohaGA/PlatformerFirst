public class AidKit: Loot
{
    public float CountHealth { get; private set; } = 10;

    public override void Take(ITakerLoot taker)
    {
        taker.Take(this);
    }
}