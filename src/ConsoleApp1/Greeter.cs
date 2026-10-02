namespace ConsoleApp1;

/// <summary>
/// 生成问候语，用于演示字符串逻辑的单元测试。
/// </summary>
public class Greeter
{
    public string Greet(string name)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        return $"Hello, {name}!";
    }
}
