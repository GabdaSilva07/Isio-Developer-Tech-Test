namespace GildedRoseKata;

internal static class ItemRuleTypeResolver
{
    public static ItemRuleType Resolve(Item item)
    {
        if (item.Name == ItemNames.AgedBrie)
        {
            return ItemRuleType.AgedBrie;
        }

        if (item.Name == ItemNames.Sulfuras)
        {
            return ItemRuleType.Sulfuras;
        }

        if (item.Name == ItemNames.BackstagePass)
        {
            return ItemRuleType.BackstagePass;
        }

        if (item.Name.StartsWith(ItemNames.ConjuredPrefix))
        {
            return ItemRuleType.Conjured;
        }

        return ItemRuleType.Normal;
    }
}
