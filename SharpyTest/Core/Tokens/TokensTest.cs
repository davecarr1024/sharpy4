namespace Sharpy.Core.Tokens;

[TestClass]
public class TokenTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            new Token("r", new Chars.Stream()),
            new Token("r", "")
        );
        Assert.AreEqual(
            new Token("r", new Chars.Stream("abc")),
            new Token("r", "abc")
        );
        Assert.AreEqual(
            new Token("r", new Chars.Stream("abc", new(1, 0))),
            new Token("r", "abc", new(1, 0))
        );
    }
}