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
    public void Greet_NullName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _greeter.Greet(null!));
    }
}
