using System.Collections.Generic;
using GildedRoseKata.Rules;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    private readonly NormalItemRule normalItemRule = new();
    private readonly AgedBrieRule agedBrieRule = new();
    private readonly SulfurasRule sulfurasRule = new();
    private readonly BackstagePassRule backstagePassRule = new();
    private readonly ConjuredItemRule conjuredItemRule = new();

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var itemRuleType = ItemRuleTypeResolver.Resolve(Items[i]);

            if (itemRuleType == ItemRuleType.Normal)
            {
                normalItemRule.Update(Items[i]);
                continue;
            }

            if (itemRuleType == ItemRuleType.AgedBrie)
            {
                agedBrieRule.Update(Items[i]);
                continue;
            }

            if (itemRuleType == ItemRuleType.Sulfuras)
            {
                sulfurasRule.Update(Items[i]);
                continue;
            }

            if (itemRuleType == ItemRuleType.BackstagePass)
            {
                backstagePassRule.Update(Items[i]);
                continue;
            }

            if (itemRuleType == ItemRuleType.Conjured)
            {
                conjuredItemRule.Update(Items[i]);
            }
        }
    }
}
