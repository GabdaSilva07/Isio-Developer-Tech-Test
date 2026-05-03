namespace GildedRoseKata.Rules;

public class BackstagePassRule : ItemRuleBase
{
    public override ItemRuleType RuleType => ItemRuleType.BackstagePass;

    public override void Update(Item item)
    {
        if (item.SellIn <= 0)
        {
            DecreaseSellIn(item);
            item.Quality = 0;
            return;
        }

        var qualityIncreaseAmount = 1;

        if (item.SellIn <= 7)
        {
            qualityIncreaseAmount = 3;
        }

        if (item.SellIn <= 2)
        {
            qualityIncreaseAmount = 4;
        }

        IncreaseQuality(item, qualityIncreaseAmount);
        DecreaseSellIn(item);
    }
}
