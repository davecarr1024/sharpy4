namespace Sharpy.Core.Chars;

[TestClass]
public class StreamTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            Stream.Load(""),
            new Stream { Items = new List<Char> { } }
        );
        Assert.AreEqual(
            Stream.Load("a"),
            new Stream { Items = new List<Char> { new('a', new()) } }
        );
        Assert.AreEqual(
            Stream.Load("abc"),
            new Stream
            {
                Items = new List<Char> {
                new('a',new()),
                new('b',new(0,1)),
                new('c',new(0,2)),
                }
            }
        );
        Assert.AreEqual(
            Stream.Load("a\nb"),
            new Stream
            {
                Items = new List<Char> {
                new('a',new()),
                new('\n',new(0,1)),
                new('b',new(1,0)),
                }
            }
        );
    }
}