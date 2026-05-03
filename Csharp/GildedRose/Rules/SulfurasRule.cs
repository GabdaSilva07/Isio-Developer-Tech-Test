namespace GildedRoseKata.Rules;

public class SulfurasRule : ItemRuleBase
{
    public override ItemRuleType RuleType => ItemRuleType.Sulfuras;

    public override void Update(Item item)
    {
        // Sulfuras is legendary, so sell-in and quality do not change.
    }
}
