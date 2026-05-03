using Xunit;
using System.Collections.Generic;
using GildedRoseKata.Domain;
using GildedRoseKata.Services;

namespace GildedRoseTests;

public class GildedRoseTests
{
    #region Normal Items

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

    #endregion

    #region Aged Brie

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
    public void UpdateQuality_DoesNotIncreaseAgedBrieQualityAboveForty()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Aged Brie", SellIn = 2, Quality = 40 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(40, Items[0].Quality);
    }

    #endregion

    #region Sulfuras

    [Fact]
    public void UpdateQuality_DoesNotChangeSulfuras()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(80, Items[0].Quality);
    }

    #endregion

    #region Backstage Passes

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
    public void UpdateQuality_IncreasesBackstagePassQualityByOneWhenMoreThanSevenDaysLeft()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(21, Items[0].Quality);
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
    public void UpdateQuality_DoesNotIncreaseBackstagePassQualityAboveForty()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 39 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(40, Items[0].Quality);
    }

    #endregion

    #region Conjured Items

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

    [Fact]
    public void UpdateQuality_DoesNotReduceConjuredItemQualityBelowZero()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new() { Name = "Conjured Mana Cake", SellIn = 0, Quality = 2 } };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, Items[0].Quality);
    }

    #endregion

    #region General Behaviour

    [Fact]
    public void UpdateQuality_UpdatesMultipleItemsInOneCall()
    {
        // Arrange
        IList<Item> Items = new List<Item>
        {
            new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 },
            new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        var normalItem = Items[0];
        var agedBrie = Items[1];
        var backstagePass = Items[2];
        var conjuredItem = Items[3];

        Assert.Equal(9, normalItem.SellIn);
        Assert.Equal(19, normalItem.Quality);

        Assert.Equal(1, agedBrie.SellIn);
        Assert.Equal(1, agedBrie.Quality);

        Assert.Equal(6, backstagePass.SellIn);
        Assert.Equal(23, backstagePass.Quality);

        Assert.Equal(2, conjuredItem.SellIn);
        Assert.Equal(4, conjuredItem.Quality);
    }

    [Fact]
    public void UpdateQuality_UpdatesMultipleItemsOverTenDays()
    {
        // Arrange
        IList<Item> Items = new List<Item>
        {
            new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 20 },
            new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };
        GildedRose app = new GildedRose(Items);

        // Act
        for (var day = 0; day < 10; day++)
        {
            app.UpdateQuality();
        }

        // Assert
        var normalItem = Items[0];
        var agedBrie = Items[1];
        var sulfuras = Items[2];
        var backstagePass = Items[3];
        var conjuredItem = Items[4];

        Assert.Equal(0, normalItem.SellIn);
        Assert.Equal(10, normalItem.Quality);

        Assert.Equal(-8, agedBrie.SellIn);
        Assert.Equal(18, agedBrie.Quality);

        Assert.Equal(0, sulfuras.SellIn);
        Assert.Equal(80, sulfuras.Quality);

        Assert.Equal(-7, backstagePass.SellIn);
        Assert.Equal(0, backstagePass.Quality);

        Assert.Equal(-7, conjuredItem.SellIn);
        Assert.Equal(0, conjuredItem.Quality);
    }

    [Fact]
    public void UpdateQuality_DoesNothingWhenThereAreNoItems()
    {
        // Arrange
        IList<Item> Items = new List<Item>();
        GildedRose app = new GildedRose(Items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Empty(Items);
    }

    #endregion
}
