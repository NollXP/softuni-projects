using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dictonaryOne = new();
        Dictionary<string, int> dictonaryTwo = new();
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictonaryOne, dictonaryTwo);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dictonaryOne = new()
        {
            {"One", 1},
            {"Two", 2},
        };
        Dictionary<string, int> dictonaryTwo = new();
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictonaryOne, dictonaryTwo);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dictonaryOne = new()
        {
            {"One", 1},
            {"Two", 2},
        };
        Dictionary<string, int> dictonaryTwo = new()
        {
            { "Three", 3},
            { "Five", 5},
        };
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictonaryTwo, dictonaryOne);
        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        Dictionary<string, int> dictonaryOne = new()
        {
            {"One", 1},
            {"Two", 2},
        };
        Dictionary<string, int> dictonaryTwo = new()
        {
            {"One", 1},
            {"Two", 2},
        };
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictonaryTwo, dictonaryOne);
        //Assert
        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dictonaryOne = new()
        {
            {"One", 1},
            {"Two", 2},
        };
        Dictionary<string, int> dictonaryTwo = new()
        {
            {"One", 3},
            {"Two", 4},
        };
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictonaryTwo, dictonaryOne);
        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
}
