using System.Collections.Immutable;

namespace Sharpy.Core.Chars;

[TestClass]
public class StreamTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            new Stream(),
            new Stream()
        );
        Assert.AreEqual(
            new Stream("a"),
            new Stream(ImmutableList.Create(new Char('a')))
        );
        Assert.AreEqual(
            new Stream("abc"),
            new Stream(ImmutableList.Create(
                new Char('a'),
                new Char('b', new(0, 1)),
                new Char('c', new(0, 2))
            ))
        );
        Assert.AreEqual(
            new Stream("a\nb"),
            new Stream(ImmutableList.Create(
                new Char('a'),
                new Char('\n', new(0, 1)),
                new Char('b', new(1, 0))
            ))
        );
    }
}