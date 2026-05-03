using System.Collections.Generic;
using GildedRoseKata.Rules;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    private readonly IDictionary<ItemRuleType, ItemRuleBase> itemRules = new Dictionary<ItemRuleType, ItemRuleBase>
    {
        { ItemRuleType.Normal, new NormalItemRule() },
        { ItemRuleType.AgedBrie, new AgedBrieRule() },
        { ItemRuleType.Sulfuras, new SulfurasRule() },
        { ItemRuleType.BackstagePass, new BackstagePassRule() },
        { ItemRuleType.Conjured, new ConjuredItemRule() }
    };

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var itemRuleType = ItemRuleTypeResolver.Resolve(Items[i]);
            itemRules[itemRuleType].Update(Items[i]);
        }
    }
}
