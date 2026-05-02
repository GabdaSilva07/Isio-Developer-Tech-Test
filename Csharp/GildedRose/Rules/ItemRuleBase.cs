using System;

namespace GildedRoseKata.Rules;

public abstract class ItemRuleBase
{
    private const int MaximumQuality = 40;

    public abstract ItemRuleType RuleType { get; }

    public abstract void Update(Item item);

    protected static void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }

    protected static void IncreaseQuality(Item item, int amount)
    {
        item.Quality = Math.Min(MaximumQuality, item.Quality + amount);
    }

    protected static void DecreaseQuality(Item item, int amount)
    {
        item.Quality = Math.Max(0, item.Quality - amount);
    }
}
