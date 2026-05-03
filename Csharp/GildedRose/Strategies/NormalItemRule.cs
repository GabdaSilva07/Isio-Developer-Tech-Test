using GildedRoseKata.Domain;

namespace GildedRoseKata.Strategies;

public class NormalItemRule : ItemRuleBase
{
    public override bool Matches(Item item)
    {
        return true;
    }

    public override void Update(Item item)
    {
        DecreaseSellIn(item);

        var qualityDecreaseAmount = item.SellIn < 0 ? 2 : 1;

        DecreaseQuality(item, qualityDecreaseAmount);
    }
}
