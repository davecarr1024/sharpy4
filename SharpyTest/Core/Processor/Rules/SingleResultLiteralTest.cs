namespace Sharpy.Core.Processor.Rules;

[TestClass]
public class SingleResultLiteralTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestCall()
    {
        SingleResultsLiteral<States.LexerState, Result> rule = new(
            new Lexer.Rule("int", @"\d+"),
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
                new States.LexerState(("str", "a")),
                new Scope<States.LexerState, Result>()
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("int", "1")),
                new Scope<States.LexerState, Result>()
            ),
            new States.StateAndSingleResults<States.LexerState, Result>(
                new States.LexerState(),
                new Result(1)
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("int", "1"), ("str", "a")),
                new Scope<States.LexerState, Result>()
            ),
            new States.StateAndSingleResults<States.LexerState, Result>(
                new States.LexerState(("str", "a")),
                new Result(1)
            )
        );
    }
}