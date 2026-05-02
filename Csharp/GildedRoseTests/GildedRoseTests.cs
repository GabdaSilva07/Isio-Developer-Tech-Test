using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Fact]
    public void UpdateQuality_DoesNotChangeNormalItemName()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal("+5 Dexterity Vest", Items[0].Name);
    }

    [Fact]
    public void UpdateQuality_ReducesNormalItemSellInByOne()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(9, Items[0].SellIn);
    }

    [Fact]
    public void UpdateQuality_ReducesNormalItemQualityByOneBeforeSellDate()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(19, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ReducesNormalItemQualityByTwoAfterSellDate()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(18, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_DoesNotReduceNormalItemQualityBelowZero()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, Items[0].Quality);
    }
}
