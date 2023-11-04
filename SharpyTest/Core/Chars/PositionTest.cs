namespace Sharpy.Core.Chars
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(
                new Position(1, 2) + new Char('a', new()),
                new Position(1, 3)
            );
            Assert.AreEqual(
                new Position(1, 2) + new Char('\n', new()),
                new Position(2, 0)
            );
        }
    }
}