using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Domain;
using GildedRoseKata.Strategies;

namespace GildedRoseKata.Services;

public class GildedRose
{
    IList<Item> Items;
    private readonly IList<ItemRuleBase> itemRules = new List<ItemRuleBase>
    {
        new AgedBrieRule(),
        new SulfurasRule(),
        new BackstagePassRule(),
        new ConjuredItemRule(),
        new NormalItemRule()
    };

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var itemRule = itemRules.First(rule => rule.Matches(Items[i]));
            itemRule.Update(Items[i]);
        }
    }
}
