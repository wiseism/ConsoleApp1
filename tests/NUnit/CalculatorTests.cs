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

    [Test]
    public void Sqrt_PositiveValue_ReturnsSquareRoot()
    {
        Assert.That(_calculator.Sqrt(9.0), Is.EqualTo(3.0).Within(1e-9));
    }

    [Test]
    public void Sqrt_NegativeValue_ThrowsArgumentOutOfRangeException()
    {
        Assert.That(() => _calculator.Sqrt(-1.0), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Power_ReturnsExpectedValue()
    {
        Assert.That(_calculator.Power(2.0, 10.0), Is.EqualTo(1024.0));
    }

    [Test]
    public void Sum_FloatingPointResult_IsNotExactlyEqual()
    {
        double sum = _calculator.Sum(new[] { 0.1, 0.2 });

        // 二进制浮点误差：0.1 + 0.2 并不精确等于 0.3
        Assert.That(sum, Is.Not.EqualTo(0.3));
        Assert.That(Calculator.IsCloseTo(sum, 0.3), Is.True);
        Assert.That(Calculator.IsCloseTo(sum, 0.4), Is.False);
    }

    [Test]
    public void Sum_AssertedWithTolerance()
    {
        double sum = _calculator.Sum(new[] { 0.1, 0.2, 0.3 });

        // NUnit 支持 Within 容差断言
        Assert.That(sum, Is.EqualTo(0.6).Within(1e-9));
    }

    [Test]
    public void Sum_EmptySequence_ReturnsZero()
    {
        Assert.That(_calculator.Sum(Array.Empty<double>()), Is.EqualTo(0.0));
    }

    [Test]
    public void Sum_NullSequence_ThrowsArgumentNullException()
    {
        Assert.That(() => _calculator.Sum(null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Average_ReturnsMean()
    {
        Assert.That(_calculator.Average(new[] { 1.0, 2.0, 3.0, 4.0 }), Is.EqualTo(2.5));
    }

    [Test]
    public void Average_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.That(() => _calculator.Average(Array.Empty<double>()), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void Max_ReturnsLargestValue()
    {
        Assert.That(_calculator.Max(new[] { 3.0, 9.0, 1.0 }), Is.EqualTo(9.0));
    }

    [Test]
    public void Min_ReturnsSmallestValue()
    {
        Assert.That(_calculator.Min(new[] { 3.0, 9.0, 1.0 }), Is.EqualTo(1.0));
    }

    [Test]
    public void Max_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.That(() => _calculator.Max(Array.Empty<double>()), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void Min_EmptySequence_ThrowsInvalidOperationException()
    {
        Assert.That(() => _calculator.Min(Array.Empty<double>()), Throws.TypeOf<InvalidOperationException>());
    }
}
