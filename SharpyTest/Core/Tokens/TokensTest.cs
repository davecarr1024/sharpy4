namespace Sharpy.Core.Tokens;

[TestClass]
public class TokenTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            Token.Load("r", Chars.Stream.Load("")),
            new Token("r", "", new())
        );
        Assert.AreEqual(
            Token.Load("r", Chars.Stream.Load("abc")),
            new Token("r", "abc", new())
        );
        Assert.AreEqual(
            Token.Load("r", Chars.Stream.Load("abc", new(1, 0))),
            new Token("r", "abc", new(1, 0))
        );
    }
}