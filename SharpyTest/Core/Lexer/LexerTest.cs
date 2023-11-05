namespace Sharpy.Core.Lexer;

[TestClass]
public class LexerTest
{
    [TestMethod]
    public void TestCall()
    {
        Lexer lexer = new(("r", "a"), ("s", "b"));
        Assert.AreEqual(
            lexer.Call(""),
            new Tokens.Stream()
        );
        Assert.AreEqual(
            lexer.Call("a"),
            new Tokens.Stream(new Tokens.Token("r", "a"))
        );
        Assert.AreEqual(
            lexer.Call("b"),
            new Tokens.Stream(new Tokens.Token("s", "b"))
        );
        Assert.AreEqual(
            lexer.Call("ab"),
            new Tokens.Stream(
                new Tokens.Token("r", "a"),
                new Tokens.Token("s", "b", new(0, 1))
            )
        );
    }
}