using ConsoleApp1;
using NUnit.Framework;

namespace ConsoleApp1.Tests.NUnit;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnsSum()
    {
        Assert.That(_calculator.Add(2, 3), Is.EqualTo(5));
    }

    [Test]
    public void Subtract_ReturnsDifference()
    {
        Assert.That(_calculator.Subtract(3, 2), Is.EqualTo(1));
    }

    [Test]
    public void Multiply_ReturnsProduct()
    {
        Assert.That(_calculator.Multiply(2, 3), Is.EqualTo(6));
    }

    [Test]
    public void Divide_ReturnsQuotient()
    {
        Assert.That(_calculator.Divide(10.0, 2.0), Is.EqualTo(5.0));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.That(() => _calculator.Divide(10.0, 0.0), Throws.TypeOf<DivideByZeroException>());
    }
}
