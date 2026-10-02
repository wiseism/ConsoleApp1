namespace ConsoleApp1;

/// <summary>
/// 计算器：四则运算、浮点运算（开方/幂）与集合聚合（求和/平均/极值）。
/// </summary>
public class Calculator
{
    /// <summary>浮点比较时使用的默认容差。</summary>
    public const double DefaultTolerance = 1e-9;

    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Denominator must not be zero.");
        }

        return a / b;
    }

    /// <summary>开平方；负数抛出 <see cref="ArgumentOutOfRangeException"/>。</summary>
    public double Sqrt(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "Value must not be negative.");
        }

        return Math.Sqrt(value);
    }

    /// <summary>幂运算。</summary>
    public double Power(double baseValue, double exponent) => Math.Pow(baseValue, exponent);

    /// <summary>
    /// 浮点近似相等判断。double 的二进制精度误差会让 <c>0.1 + 0.2 == 0.3</c> 为 false，
    /// 因此比较浮点结果时应基于容差，而不是直接用 <c>==</c>。
    /// </summary>
    public static bool IsCloseTo(double a, double b, double tolerance = DefaultTolerance)
        => Math.Abs(a - b) <= tolerance;

    /// <summary>求和；空序列返回 0。</summary>
    public double Sum(IEnumerable<double> values)
    {
        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        double total = 0;
        foreach (double value in values)
        {
            total += value;
        }

        return total;
    }

    /// <summary>平均值；空序列抛出 <see cref="InvalidOperationException"/>。</summary>
    public double Average(IEnumerable<double> values)
        => MaterializeNonEmpty(values, "average").Average();

    /// <summary>最大值；空序列抛出 <see cref="InvalidOperationException"/>。</summary>
    public double Max(IEnumerable<double> values)
        => MaterializeNonEmpty(values, "max").Max();

    /// <summary>最小值；空序列抛出 <see cref="InvalidOperationException"/>。</summary>
    public double Min(IEnumerable<double> values)
        => MaterializeNonEmpty(values, "min").Min();

    private static List<double> MaterializeNonEmpty(IEnumerable<double> values, string operation)
    {
        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        List<double> items = values.ToList();
        if (items.Count == 0)
        {
            throw new InvalidOperationException($"Cannot compute {operation} of an empty sequence.");
        }

        return items;
    }
}
