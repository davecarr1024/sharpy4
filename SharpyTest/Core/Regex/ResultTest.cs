using System.Collections.Immutable;

namespace Sharpy.Core.Regex;

[TestClass]
public class RegexTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            new Result(),
            new Result()
        );
        Assert.AreEqual(
            new Result("a"),
            new Result(new Chars.Char('a'))
        );
        Assert.AreEqual(
            new Result("a", new(1, 0)),
            new Result(new Chars.Char('a', new(1, 0)))
        );
    }

    [TestMethod]
    public void TestPosition()
    {
        Assert.AreEqual(
            new Result().Position(),
            new Chars.Position()
        );
        Assert.AreEqual(
            new Result("a").Position(),
            new Chars.Position()
        );
        Assert.AreEqual(
            new Result("a", new(1, 0)).Position(),
            new Chars.Position(1, 0)
        );
    }

    [TestMethod]
    public void TestToken()
    {
        Assert.AreEqual(
            new Result("a").Token("r"),
            new Tokens.Token("r", "a")
        );
        Assert.AreEqual(
            new Result("a", new(1, 0)).Token("r"),
            new Tokens.Token("r", "a", new(1, 0))
        );
    }

    [TestMethod]
    public void TestAdd()
    {
        Assert.AreEqual(
            new Result() + new Result(),
            new Result()
        );
        Assert.AreEqual(
            new Result("a") + new Result(),
            new Result("a")
        );
        Assert.AreEqual(
            new Result() + new Result("b"),
            new Result("b")
        );
        Assert.AreEqual(
            new Result("a") + new Result("b"),
            new Result(new Chars.Char('a'), new Chars.Char('b'))
        );
    }
}