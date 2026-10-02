namespace ConsoleApp1;

/// <summary>
/// 问候生成器：处理字符串边界（null / 空白 / 首尾空格）与集合批量问候。
/// </summary>
public class Greeter
{
    /// <summary>
    /// 生成问候语。会先去除首尾空白；空字符串或纯空白视为非法输入。
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> 为 null。</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> 为空白字符串。</exception>
    public string Greet(string name)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        string trimmed = name.Trim();
        if (trimmed.Length == 0)
        {
            throw new ArgumentException("Name must not be empty or whitespace.", nameof(name));
        }

        return $"Hello, {trimmed}!";
    }

    /// <summary>
    /// 批量生成问候语。会跳过 null 与空白项，其余项按 <see cref="Greet"/> 处理。
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="names"/> 为 null。</exception>
    public IReadOnlyList<string> GreetAll(IEnumerable<string> names)
    {
        if (names is null)
        {
            throw new ArgumentNullException(nameof(names));
        }

        List<string> greetings = new();
        foreach (string name in names)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }

            greetings.Add(Greet(name));
        }

        return greetings;
    }
}
