namespace GildedRoseKata.Rules;

public class ConjuredItemRule : ItemRuleBase
{
    public override ItemRuleType RuleType => ItemRuleType.Conjured;

    public override void Update(Item item)
    {
        DecreaseSellIn(item);

        var qualityDecreaseAmount = item.SellIn < 0 ? 4 : 2;

        DecreaseQuality(item, qualityDecreaseAmount);
    }
}
