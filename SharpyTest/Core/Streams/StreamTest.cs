namespace Sharpy.Core.Streams
{
    [TestClass]
    public class StreamTest
    {
        private class TestStream : Stream<TestStream, int> { }

        [TestMethod]
        public void TestHead()
        {
            Assert.ThrowsException<Errors.Error>(() => new TestStream().Head());
            Assert.AreEqual(new TestStream() { Items = new List<int> { 1 } }.Head(), 1);
            Assert.AreEqual(new TestStream() { Items = new List<int> { 1, 2 } }.Head(), 1);
        }

        [TestMethod]
        public void TestTail()
        {
            Assert.ThrowsException<Errors.Error>(() => new TestStream().Tail());
            Assert.AreEqual(new TestStream() { Items = new List<int> { 1 } }.Tail(), new TestStream());
            Assert.AreEqual(
                new TestStream() { Items = new List<int> { 1, 2 } }.Tail(),
                new TestStream() { Items = new List<int> { 2 } }
            );
        }
    }
}