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

    [Fact]
    public void UpdateQuality_IncreasesAgedBrieQualityByOne()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(1, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_DropsBackstagePassQualityToZeroAfterConcert()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_IncreasesBackstagePassQualityByThreeWhenSevenDaysOrLess()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_IncreasesBackstagePassQualityByFourWhenTwoDaysOrLess()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(24, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ReducesConjuredItemQualityByTwoBeforeSellDate()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ReducesConjuredItemQualityByFourAfterSellDate()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(2, Items[0].Quality);
    }
}
