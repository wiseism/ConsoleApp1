using Xunit;

namespace MyNamespace.Tests
{
    public class MyTests2
    {
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            int expected = 2;
            int actual = 1 + 1;

            // Act & Assert
            Assert.Equal(expected, actual);
        }
    }
}
