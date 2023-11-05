using System.Collections.Immutable;

namespace Sharpy.Core.Regex;

[TestClass]
public class RegexTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            Result.Load(""),
            new Result()
        );
        Assert.AreEqual(
            Result.Load("a"),
            new Result(ImmutableList.Create(new Chars.Char('a', new())))
        );
        Assert.AreEqual(
            Result.Load("a", new(1, 0)),
            new Result(ImmutableList.Create(new Chars.Char('a', new(1, 0))))
        );
    }

    [TestMethod]
    public void TestPosition()
    {
        Assert.AreEqual(
            Result.Load("").Position(),
            new Chars.Position()
        );
        Assert.AreEqual(
            Result.Load("a").Position(),
            new Chars.Position()
        );
        Assert.AreEqual(
            Result.Load("a", new(1, 0)).Position(),
            new Chars.Position(1, 0)
        );
    }

    [TestMethod]
    public void TestToken()
    {
        Assert.AreEqual(
            Result.Load("a").Token("r"),
            new Tokens.Token("r", "a", new())
        );
        Assert.AreEqual(
            Result.Load("a", new(1, 0)).Token("r"),
            new Tokens.Token("r", "a", new(1, 0))
        );
    }
}