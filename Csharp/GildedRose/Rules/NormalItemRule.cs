namespace GildedRoseKata.Rules;

public class NormalItemRule : ItemRuleBase
{
    public override ItemRuleType RuleType => ItemRuleType.Normal;

    public override void Update(Item item)
    {
        DecreaseSellIn(item);

        var qualityDecreaseAmount = item.SellIn < 0 ? 2 : 1;

        DecreaseQuality(item, qualityDecreaseAmount);
    }
}
