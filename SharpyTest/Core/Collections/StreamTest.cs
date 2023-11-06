using System.Collections.Immutable;

namespace Sharpy.Core.Containers
{
    [TestClass]
    public class StreamTest
    {
        private class TestStream : Stream<TestStream, int>
        {
            public TestStream() : base() { }

            public TestStream(params int[] values) : base(values) { }
        }

        [TestMethod]
        public void TestHead()
        {
            Assert.ThrowsException<Errors.Error>(() => new TestStream().Head);
            Assert.AreEqual(
                new TestStream(1).Head,
                1
            );
            Assert.AreEqual(
                new TestStream(1, 2).Head,
                1
            );
        }

        [TestMethod]
        public void TestTail()
        {
            Assert.ThrowsException<Errors.Error>(() => new TestStream().Tail);
            Assert.AreEqual(
                new TestStream(1).Tail,
                new TestStream()
            );
            Assert.AreEqual(
                new TestStream(1, 2).Tail,
                new TestStream(2)
            );
        }
    }
}