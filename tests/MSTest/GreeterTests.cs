using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests.MSTest;

[TestClass]
public class GreeterTests
{
    private readonly Greeter _greeter = new();

    [TestMethod]
    public void Greet_ReturnsExpectedGreeting()
    {
        Assert.AreEqual("Hello, World!", _greeter.Greet("World"));
    }

    [TestMethod]
    public void Greet_TrimsSurroundingWhitespace()
    {
        Assert.AreEqual("Hello, World!", _greeter.Greet("   World   "));
    }

    [TestMethod]
    public void Greet_NullName_ThrowsArgumentNullException()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => _greeter.Greet(null!));
    }

    [TestMethod]
    public void Greet_EmptyName_ThrowsArgumentException()
    {
        Assert.ThrowsExactly<ArgumentException>(() => _greeter.Greet(string.Empty));
    }

    [TestMethod]
    public void Greet_WhitespaceName_ThrowsArgumentException()
    {
        Assert.ThrowsExactly<ArgumentException>(() => _greeter.Greet("   "));
    }

    [TestMethod]
    public void GreetAll_ReturnsGreetingForEachName()
    {
        IReadOnlyList<string> greetings = _greeter.GreetAll(new[] { "Ada", "Linus" });

        Assert.AreEqual(2, greetings.Count);
        Assert.AreEqual("Hello, Ada!", greetings[0]);
        Assert.AreEqual("Hello, Linus!", greetings[1]);
    }

    [TestMethod]
    public void GreetAll_SkipsNullAndWhitespaceEntries()
    {
        IReadOnlyList<string> greetings = _greeter.GreetAll(new[] { "Ada", null!, "   ", "Linus" });

        Assert.AreEqual(2, greetings.Count);
        Assert.AreEqual("Hello, Ada!", greetings[0]);
        Assert.AreEqual("Hello, Linus!", greetings[1]);
    }

    [TestMethod]
    public void GreetAll_EmptySequence_ReturnsEmptyList()
    {
        Assert.AreEqual(0, _greeter.GreetAll(Array.Empty<string>()).Count);
    }

    [TestMethod]
    public void GreetAll_NullSequence_ThrowsArgumentNullException()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => _greeter.GreetAll(null!));
    }
}
