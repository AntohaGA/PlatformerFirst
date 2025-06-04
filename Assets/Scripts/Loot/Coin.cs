public class Coin : Loot
{
    public float Price { get; private set; } = 1;

    public override void Take(ITakerLoot taker)
    {
        taker.Take(this);
    }
}