using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        //Arrange
        string input = string.Empty;

        //Act
        string result = StringRotator.RotateRight(input, 99);
        //Assert
        Assert.AreEqual(input, result);
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        //Arrange
        string input = "hello!";

        //Act
        string result = StringRotator.RotateRight(input, 0);
        //Assert
        Assert.AreEqual(input, result);
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        //Arrange
        string input = "Hello!";
        string expected = "o!Hell";
        //Act
        string result = StringRotator.RotateRight(input, 2);
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        //Arrange
        string input = "Hello!";
        string expected = "!Hello";
        //Act
        string result = StringRotator.RotateRight(input, -1);
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        //Arrange
        string input = "Hello!";
        string expected = "!Hello";
        //Act
        string result = StringRotator.RotateRight(input, 7);
        //Assert
        Assert.AreEqual(expected, result);
    }
}
