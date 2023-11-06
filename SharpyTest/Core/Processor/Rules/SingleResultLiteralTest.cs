namespace Sharpy.Core.Processor.Rules;

[TestClass]
public class SingleResultLiteralTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestCall()
    {
        SingleResultsLiteral<States.LexerState, Result> rule = new(
            new Lexer.Rule("r", "a"),
            token => new Result(int.Parse(token.Value))
        );
        Assert.ThrowsException<SingleResultsLiteral<States.LexerState, Result>.Error>(
            () => rule.Call(
                new States.LexerState(),
                new Scope<States.LexerState, Result>()
            )
        );
        Assert.ThrowsException<SingleResultsLiteral<States.LexerState, Result>.Error>(
            () => rule.Call(
                new States.LexerState(("s", "2")),
                new Scope<States.LexerState, Result>()
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("r", "1")),
                new Scope<States.LexerState, Result>()
            ),
            new States.StateAndSingleResults<States.LexerState, Result>(
                new States.LexerState(),
                new Result(1)
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("r", "1"), ("s", "2")),
                new Scope<States.LexerState, Result>()
            ),
            new States.StateAndSingleResults<States.LexerState, Result>(
                new States.LexerState(("s", "2")),
                new Result(1)
            )
        );
    }
}