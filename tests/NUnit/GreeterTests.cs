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
    public void Greet_TrimsSurroundingWhitespace()
    {
        Assert.That(_greeter.Greet("   World   "), Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void Greet_NullName_ThrowsArgumentNullException()
    {
        Assert.That(() => _greeter.Greet(null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Greet_EmptyName_ThrowsArgumentException()
    {
        Assert.That(() => _greeter.Greet(string.Empty), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Greet_WhitespaceName_ThrowsArgumentException()
    {
        Assert.That(() => _greeter.Greet("   "), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void GreetAll_ReturnsGreetingForEachName()
    {
        IReadOnlyList<string> greetings = _greeter.GreetAll(new[] { "Ada", "Linus" });

        Assert.That(greetings.Count, Is.EqualTo(2));
        Assert.That(greetings[0], Is.EqualTo("Hello, Ada!"));
        Assert.That(greetings[1], Is.EqualTo("Hello, Linus!"));
    }

    [Test]
    public void GreetAll_SkipsNullAndWhitespaceEntries()
    {
        IReadOnlyList<string> greetings = _greeter.GreetAll(new[] { "Ada", null!, "   ", "Linus" });

        Assert.That(greetings.Count, Is.EqualTo(2));
        Assert.That(greetings[0], Is.EqualTo("Hello, Ada!"));
        Assert.That(greetings[1], Is.EqualTo("Hello, Linus!"));
    }

    [Test]
    public void GreetAll_EmptySequence_ReturnsEmptyList()
    {
        Assert.That(_greeter.GreetAll(Array.Empty<string>()), Is.Empty);
    }

    [Test]
    public void GreetAll_NullSequence_ThrowsArgumentNullException()
    {
        Assert.That(() => _greeter.GreetAll(null!), Throws.TypeOf<ArgumentNullException>());
    }
}
