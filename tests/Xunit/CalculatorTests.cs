using ConsoleApp1;
using Xunit;

namespace ConsoleApp1.Tests.Xunit;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Fact]
    public void Add_ReturnsSum()
    {
        Assert.Equal(5, _calculator.Add(2, 3));
    }

    [Fact]
    public void Subtract_ReturnsDifference()
    {
        Assert.Equal(1, _calculator.Subtract(3, 2));
    }

    [Fact]
    public void Multiply_ReturnsProduct()
    {
        Assert.Equal(6, _calculator.Multiply(2, 3));
    }

    [Fact]
    public void Divide_ReturnsQuotient()
    {
        Assert.Equal(5.0, _calculator.Divide(10.0, 2.0));
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10.0, 0.0));
    }

    [Fact]
    public void Sqrt_PositiveValue_ReturnsSquareRoot()
    {
        Assert.Equal(3.0, _calculator.Sqrt(9.0), 9);
    }

    [Fact]
    public void Sqrt_NegativeValue_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Sqrt(-1.0));
    }

    [Fact]
    public void Power_ReturnsExpectedValue()
    {
        Assert.Equal(1024.0, _calculator.Power(2.0, 10.0));
    }

    [Fact]
    public void Sum_FloatingPointResult_IsNotExactlyEqual()
    {
        double sum = _calculator.Sum(new[] { 0.1, 0.2 });

        // 二进制浮点误差：0.1 + 0.2 并不精确等于 0.3
        Assert.NotEqual(0.3, sum);
        Assert.True(Calculator.IsCloseTo(sum, 0.3));
        Assert.False(Calculator.IsCloseTo(sum, 0.4));
    }

    [Fact]
    public void Sum_AssertedWithPrecision()
    {
        double sum = _calculator.Sum(new[] { 0.1, 0.2, 0.3 });

        // xUnit 支持按小数位数做精度断言
        Assert.Equal(0.6, sum, 9);
    }

    [Fact]
    public void Sum_EmptySequence_ReturnsZero()
    {
        Assert.Equal(0.0, _calculator.Sum(Array.Empty<double>()));
    }

    [Fact]
    public void Sum_NullSequence_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _calculator.Sum(null!));
    }

    [Fact]
    public void Average_ReturnsMean()
    {
        Assert.Equal(2.5, _calculator.Average(new[] { 1.0, 2.0, 3.0, 4.0 }));
    }

    [Fact]
    public void Average_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.Average(Array.Empty<double>()));
    }

    [Fact]
    public void Max_ReturnsLargestValue()
    {
        Assert.Equal(9.0, _calculator.Max(new[] { 3.0, 9.0, 1.0 }));
    }

    [Fact]
    public void Min_ReturnsSmallestValue()
    {
        Assert.Equal(1.0, _calculator.Min(new[] { 3.0, 9.0, 1.0 }));
    }

    [Fact]
    public void Max_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.Max(Array.Empty<double>()));
    }

    [Fact]
    public void Min_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.Min(Array.Empty<double>()));
    }
}
