using System.Collections.Immutable;

namespace Sharpy.Core.Chars;

[TestClass]
public class StreamTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            Stream.Load(""),
            new Stream()
        );
        Assert.AreEqual(
            Stream.Load("a"),
            new Stream(ImmutableList.Create(new Char('a', new())))
        );
        Assert.AreEqual(
            Stream.Load("abc"),
            new Stream(ImmutableList.Create(
                new Char('a', new()),
                new Char('b', new(0, 1)),
                new Char('c', new(0, 2))
            ))
        );
        Assert.AreEqual(
            Stream.Load("a\nb"),
            new Stream(ImmutableList.Create(
                new Char('a', new()),
                new Char('\n', new(0, 1)),
                new Char('b', new(1, 0))
            ))
        );
    }
}