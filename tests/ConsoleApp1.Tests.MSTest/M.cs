using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyNamespace.Tests
{
    [TestClass]
    public class MyTests3
    {
        [TestMethod]
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
