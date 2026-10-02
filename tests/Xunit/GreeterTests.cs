using ConsoleApp1;
using Xunit;

namespace ConsoleApp1.Tests.Xunit;

public class GreeterTests
{
    private readonly Greeter _greeter = new();

    [Fact]
    public void Greet_ReturnsExpectedGreeting()
    {
        Assert.Equal("Hello, World!", _greeter.Greet("World"));
    }

    [Fact]
    public void Greet_TrimsSurroundingWhitespace()
    {
        Assert.Equal("Hello, World!", _greeter.Greet("   World   "));
    }

    [Fact]
    public void Greet_NullName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _greeter.Greet(null!));
    }

    [Fact]
    public void Greet_EmptyName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _greeter.Greet(string.Empty));
    }

    [Fact]
    public void Greet_WhitespaceName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _greeter.Greet("   "));
    }

    [Fact]
    public void GreetAll_ReturnsGreetingForEachName()
    {
        IReadOnlyList<string> greetings = _greeter.GreetAll(new[] { "Ada", "Linus" });

        Assert.Equal(2, greetings.Count);
        Assert.Equal("Hello, Ada!", greetings[0]);
        Assert.Equal("Hello, Linus!", greetings[1]);
    }

    [Fact]
    public void GreetAll_SkipsNullAndWhitespaceEntries()
    {
        IReadOnlyList<string> greetings = _greeter.GreetAll(new[] { "Ada", null!, "   ", "Linus" });

        Assert.Equal(2, greetings.Count);
        Assert.Equal("Hello, Ada!", greetings[0]);
        Assert.Equal("Hello, Linus!", greetings[1]);
    }

    [Fact]
    public void GreetAll_EmptySequence_ReturnsEmptyList()
    {
        Assert.Empty(_greeter.GreetAll(Array.Empty<string>()));
    }

    [Fact]
    public void GreetAll_NullSequence_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _greeter.GreetAll(null!));
    }
}
