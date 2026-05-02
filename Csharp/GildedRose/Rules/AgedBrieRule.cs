namespace GildedRoseKata.Rules;

public class AgedBrieRule : ItemRuleBase
{
    public override ItemRuleType RuleType => ItemRuleType.AgedBrie;

    public override void Update(Item item)
    {
        DecreaseSellIn(item);

        var qualityIncreaseAmount = item.SellIn < 0 ? 2 : 1;

        IncreaseQuality(item, qualityIncreaseAmount);
    }
}
