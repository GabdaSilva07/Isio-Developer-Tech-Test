# Gilded Rose Notes

## Rules I need to keep working

- At the end of each day, most items reduce `SellIn` by 1.
- `Quality` should not go below 0.
- `Quality` should not go above 40, apart from `Sulfuras`.

Normal items:

- Quality goes down by 1 before the sell date.
- Quality goes down by 2 after the sell date.

`Aged Brie`:

- Quality increases over time.
- Quality still cannot go above 40.

`Sulfuras, Hand of Ragnaros`:

- Quality does not change.
- SellIn does not change.
- The sample data starts it at 80, but the rule I need to preserve is that it does not change.

`Backstage passes to a TAFKAL80ETC concert`:

- Quality increases as the concert gets closer.
- More than 7 days left: increase by 1.
- 7 days or fewer: increase by 3.
- 2 days or fewer: increase by 4.
- After the concert: quality becomes 0.

`Conjured` items:

- This is the new rule to add.
- They degrade twice as fast as normal items.
- Before the sell date: quality goes down by 2.
- After the sell date: quality goes down by 4.

## Refactor plan

- Keep `Item.cs` unchanged.
- Keep `GildedRose.UpdateQuality()` as the method that updates all items.
- Move the item-specific update logic out of the large nested `if` block.
- Use small rule classes for each item type.
- Let each rule decide if it matches an item.
- Keep the normal item rule as the fallback.
- Keep the design small. No repository or service layer needed for this kata.
- Add enough tests to cover the existing rules before relying on the refactor.


## Why this approach

- The main thing that changes between items is behavior.
- Strategy pattern keeps each behavior separate.
- Adding Conjured should not mean adding more nested conditions inside UpdateQuality().
- I originally considered a resolver, but letting each rule match its own item keeps the code smaller.
- The normal item rule is last because it is the fallback.
- I considered a factory-style setup as well, but for this project I think small rule classes are enough.
- If this grew into a larger stock system with more operations, such as adding, removing, patching, or restocking items, I would consider a factory for choosing the right behavior.
