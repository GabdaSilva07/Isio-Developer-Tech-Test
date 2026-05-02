using System.Collections.Generic;
using GildedRoseKata.Rules;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    private readonly NormalItemRule normalItemRule = new();
    private readonly AgedBrieRule agedBrieRule = new();

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

            if (Items[i].Name != ItemNames.BackstagePass)
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != ItemNames.Sulfuras)
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == ItemNames.BackstagePass)
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Items[i].Name != ItemNames.Sulfuras)
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != ItemNames.BackstagePass)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != ItemNames.Sulfuras)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    Items[i].Quality = Items[i].Quality - Items[i].Quality;
                }
            }
        }
    }
}
