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

    [TestMethod]
    public void Sqrt_PositiveValue_ReturnsSquareRoot()
    {
        Assert.AreEqual(3.0, _calculator.Sqrt(9.0), 1e-9);
    }

    [TestMethod]
    public void Sqrt_NegativeValue_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _calculator.Sqrt(-1.0));
    }

    [TestMethod]
    public void Power_ReturnsExpectedValue()
    {
        Assert.AreEqual(1024.0, _calculator.Power(2.0, 10.0));
    }

    [TestMethod]
    public void Sum_FloatingPointResult_IsNotExactlyEqual()
    {
        double sum = _calculator.Sum(new[] { 0.1, 0.2 });

        // 二进制浮点误差：0.1 + 0.2 并不精确等于 0.3
        Assert.AreNotEqual(0.3, sum);
        Assert.IsTrue(Calculator.IsCloseTo(sum, 0.3));
        Assert.IsFalse(Calculator.IsCloseTo(sum, 0.4));
    }

    [TestMethod]
    public void Sum_AssertedWithDelta()
    {
        double sum = _calculator.Sum(new[] { 0.1, 0.2, 0.3 });

        // MSTest 支持按容差(delta)做浮点断言
        Assert.AreEqual(0.6, sum, 1e-9);
    }

    [TestMethod]
    public void Sum_EmptySequence_ReturnsZero()
    {
        Assert.AreEqual(0.0, _calculator.Sum(Array.Empty<double>()));
    }

    [TestMethod]
    public void Sum_NullSequence_ThrowsArgumentNullException()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => _calculator.Sum(null!));
    }

    [TestMethod]
    public void Average_ReturnsMean()
    {
        Assert.AreEqual(2.5, _calculator.Average(new[] { 1.0, 2.0, 3.0, 4.0 }));
    }

    [TestMethod]
    public void Average_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => _calculator.Average(Array.Empty<double>()));
    }

    [TestMethod]
    public void Max_ReturnsLargestValue()
    {
        Assert.AreEqual(9.0, _calculator.Max(new[] { 3.0, 9.0, 1.0 }));
    }

    [TestMethod]
    public void Min_ReturnsSmallestValue()
    {
        Assert.AreEqual(1.0, _calculator.Min(new[] { 3.0, 9.0, 1.0 }));
    }

    [TestMethod]
    public void Max_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => _calculator.Max(Array.Empty<double>()));
    }

    [TestMethod]
    public void Min_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => _calculator.Min(Array.Empty<double>()));
    }
}
