using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        //Arrange
        string inpiut = string.Empty;
        //Act
        string[] result = CsvParser.ParseCsv(inpiut);
        string[] expected = Array.Empty<string>();
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        //Arrange
        string inpiut = "Hello!";
        //Act
        string[] result = CsvParser.ParseCsv(inpiut);
        string[] expected = {"Hello!"};
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        //Arrange
        string inpiut = "Hello,how,are,you";
        //Act
        string[] result = CsvParser.ParseCsv(inpiut);
        string[] expected = { "Hello", "how", "are", "you"};
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        //Arrange
        string inpiut = "Hello   ,   how   ,   are  ,  you  ";
        //Act
        string[] result = CsvParser.ParseCsv(inpiut);
        string[] expected = { "Hello", "how", "are", "you" };
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
