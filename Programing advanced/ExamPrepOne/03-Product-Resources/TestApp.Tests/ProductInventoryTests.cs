using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }

    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        //Append
        string ProductName = "Tuna";
        double ProductPrice = 8.0;
        int ProductQuantity = 5;

        string expectedInventory = $"Product Inventory:{Environment.NewLine}{ProductName} - Price: ${ProductPrice:f2} - Quantity: {ProductQuantity}";

        //act
        this._inventory.AddProduct(ProductName, ProductPrice, ProductQuantity);

        string result = this._inventory.DisplayInventory();
        //Assert
        Assert.AreEqual(expectedInventory, result);
    }

[Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        string expected = "Product Inventory:";
      
        //act
       
        string result = this._inventory.DisplayInventory();
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        //Arrange
        string firstProductName = "Tuna";
        double firstProductPrice = 8.0;
        int firstProductQuantity = 5;

        string secondProductName = "Banana";
        double secondProductPrice = 532;
        int secondProductQuantity = 7;
        //Act
        string expectedInventory = $"Product Inventory:{Environment.NewLine}{firstProductName} - Price: ${firstProductPrice:f2} " +
            $"- Quantity: {firstProductQuantity}{Environment.NewLine}{secondProductName} - Price: ${secondProductPrice:f2} " +
            $"- Quantity: {secondProductQuantity}";


        this._inventory.AddProduct(firstProductName, firstProductPrice, firstProductQuantity);
        this._inventory.AddProduct(secondProductName,secondProductPrice, secondProductQuantity);

        string result = this._inventory.DisplayInventory();
        //Assert
        Assert.AreEqual(expectedInventory, result);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        //Arrange
        //Act
        double result = this._inventory.CalculateTotalValue();
        //Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        //Arrange
        string firstProductName = "Tuna";
        double firstProductPrice = 8.5;
        int firstProductQuantity = 5;

        string secondProductName = "Banana";
        double secondProductPrice = 532;
        int secondProductQuantity = 7;
        //Act
        double expectetTotalValue = firstProductPrice * firstProductQuantity + secondProductPrice * secondProductQuantity;

        this._inventory.AddProduct(firstProductName, firstProductPrice, firstProductQuantity);
        this._inventory.AddProduct(secondProductName, secondProductPrice, secondProductQuantity);

        double result = this._inventory.CalculateTotalValue();
        //Assert
        Assert.AreEqual(expectetTotalValue, result);
    }
}
