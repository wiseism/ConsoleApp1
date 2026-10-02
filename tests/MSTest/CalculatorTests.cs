using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests.MSTest;

[TestClass]
public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [TestMethod]
    public void Add_ReturnsSum()
    {
        Assert.AreEqual(5, _calculator.Add(2, 3));
    }

    [TestMethod]
    public void Subtract_ReturnsDifference()
    {
        Assert.AreEqual(1, _calculator.Subtract(3, 2));
    }

    [TestMethod]
    public void Multiply_ReturnsProduct()
    {
        Assert.AreEqual(6, _calculator.Multiply(2, 3));
    }

    [TestMethod]
    public void Divide_ReturnsQuotient()
    {
        Assert.AreEqual(5.0, _calculator.Divide(10.0, 2.0));
    }

    [TestMethod]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.ThrowsExactly<DivideByZeroException>(() => _calculator.Divide(10.0, 0.0));
    }
}
