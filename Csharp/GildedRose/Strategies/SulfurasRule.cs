using GildedRoseKata.Constants;
using GildedRoseKata.Domain;

namespace GildedRoseKata.Strategies;

public class SulfurasRule : ItemRuleBase
{
    public override bool Matches(Item item)
    {
        return item.Name == ItemNames.Sulfuras;
    }

    public override void Update(Item item)
    {
        // Sulfuras is legendary, so sell-in and quality do not change.
    }
}
