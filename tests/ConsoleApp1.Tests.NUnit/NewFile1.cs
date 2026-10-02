using NUnit.Framework;

namespace MyNamespace.Tests
{
    public class MyTests
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            int expected = 2;
            int actual = 1 + 1;

            // Act & Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
