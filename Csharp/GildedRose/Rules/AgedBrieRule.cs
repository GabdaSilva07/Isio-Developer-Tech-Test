namespace GildedRoseKata.Rules;

public class AgedBrieRule : ItemRuleBase
{
    public override bool Matches(Item item)
    {
        return item.Name == ItemNames.AgedBrie;
    }

    public override void Update(Item item)
    {
        DecreaseSellIn(item);

        var qualityIncreaseAmount = item.SellIn < 0 ? 2 : 1;

        IncreaseQuality(item, qualityIncreaseAmount);
    }
}
