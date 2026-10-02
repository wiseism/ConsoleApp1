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
    public void Greet_NullName_ThrowsArgumentNullException()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => _greeter.Greet(null!));
    }
}
