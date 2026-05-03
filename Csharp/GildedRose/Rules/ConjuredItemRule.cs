namespace GildedRoseKata.Rules;

public class ConjuredItemRule : ItemRuleBase
{
    public override bool Matches(Item item)
    {
        return item.Name.StartsWith(ItemNames.ConjuredPrefix);
    }

    public override void Update(Item item)
    {
        DecreaseSellIn(item);

        var qualityDecreaseAmount = item.SellIn < 0 ? 4 : 2;

        DecreaseQuality(item, qualityDecreaseAmount);
    }
}
