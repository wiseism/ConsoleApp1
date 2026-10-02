namespace ConsoleApp1;

/// <summary>
/// 简单的计算器逻辑，用于演示真正的单元测试。
/// </summary>
public class Calculator
{
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
}
