namespace FizzBuzz.Tests;

using FizzBuzz.Demo;
using NUnit.Framework;

[TestFixture]
public class FizzBuzzShould
{
    [TestCase(1, "1")]
    [TestCase(2, "2")]
    [TestCase(4, "4")]
    [TestCase(7, "7")]
    public void Convert_RegularNumber_To_Self(int number, string expectedValue)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo(expectedValue));        
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    [TestCase(12)]
    public void Convert_MultiplesOf3_To_Fizz(int number)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [TestCase(5)]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(25)]
    public void Convert_MultiplesOf5_To_Buzz(int number)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [TestCase(15)]
    [TestCase(30)]
    [TestCase(45)]
    [TestCase(60)]
    public void Convert_MultiplesOf3And5_To_FizzBuzz(int number)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }
}