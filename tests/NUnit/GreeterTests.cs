using ConsoleApp1;
using NUnit.Framework;

namespace ConsoleApp1.Tests.NUnit;

[TestFixture]
public class GreeterTests
{
    private Greeter _greeter = null!;

    [SetUp]
    public void SetUp()
    {
        _greeter = new Greeter();
    }

    [Test]
    public void Greet_ReturnsExpectedGreeting()
    {
        Assert.That(_greeter.Greet("World"), Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void Greet_NullName_ThrowsArgumentNullException()
    {
        Assert.That(() => _greeter.Greet(null!), Throws.TypeOf<ArgumentNullException>());
    }
}
