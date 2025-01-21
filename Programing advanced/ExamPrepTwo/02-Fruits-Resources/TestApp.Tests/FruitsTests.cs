using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        //Arange
        Dictionary<string, int> fruits = new Dictionary<string, int>()
        {
            ["Banana"]= 5,
            ["Apple"] = 10,
        };
        string currentFruit = "Banana";
        //Act
        int result = Fruits.GetFruitQuantity(fruits, currentFruit);
        //Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        //Arange
        Dictionary<string, int> fruits = new Dictionary<string, int>()
        {
            ["Banana"] = 5,
            ["Apple"] = 10,
        };
        string currentFruit = "Orange";
        
        //Act
        int result = Fruits.GetFruitQuantity(fruits, currentFruit);
        //Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        //Arange
        Dictionary<string, int> fruits = new Dictionary<string, int>();
        string currentFruit = "Orange";

        //Act
        int result = Fruits.GetFruitQuantity(fruits, currentFruit);
        //Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        //Arange
        Dictionary<string, int> fruits = null;
        string currentFruit = "Orange";

        //Act
        int result = Fruits.GetFruitQuantity(fruits, currentFruit);
        //Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        //Arange
        Dictionary<string, int> fruits = new Dictionary<string, int>()
        {
            ["Banana"] = 5,
            ["Apple"] = 10,
        };
        string currentFruit = null;

        //Act
        int result = Fruits.GetFruitQuantity(fruits, currentFruit);
        //Assert
        Assert.That(result, Is.EqualTo(0));
    }
}
