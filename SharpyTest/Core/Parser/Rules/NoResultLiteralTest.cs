namespace Sharpy.Core.Parser.Rules;

[TestClass]
public class NoResultLiteralTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestCall()
    {
        NoResultsLiteral<States.LexerState, Result> rule = new(new Lexer.Rule("r", "a"));
        Assert.ThrowsException<NoResultsLiteral<States.LexerState, Result>.Error>(
            () => rule.Call(
                new States.LexerState(),
                new Scope<States.LexerState, Result>()
            )
        );
        Assert.ThrowsException<NoResultsLiteral<States.LexerState, Result>.Error>(
            () => rule.Call(
                new States.LexerState(("s", "b")),
                new Scope<States.LexerState, Result>()
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("r", "a")),
                new Scope<States.LexerState, Result>()
            ),
            new States.StateAndNoResults<States.LexerState, Result>(
                new States.LexerState()
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("r", "a"), ("s", "b")),
                new Scope<States.LexerState, Result>()
            ),
            new States.StateAndNoResults<States.LexerState, Result>(
                new States.LexerState(("s", "b"))
            )
        );
    }
}