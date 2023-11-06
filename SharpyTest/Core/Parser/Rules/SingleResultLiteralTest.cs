namespace Sharpy.Core.Parser.Rules;

[TestClass]
public class SingleResultLiteralTest
{
    [TestMethod]
    public void TestCall()
    {
        var rule = Int.Rule;
        Assert.ThrowsException<SingleResultsLiteral<States.LexerState, Val>.Error>(
            () => rule.Call(
                new States.LexerState()
            )
        );
        Assert.ThrowsException<SingleResultsLiteral<States.LexerState, Val>.Error>(
            () => rule.Call(
                new States.LexerState(("str", "a"))
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("int", "1"))
            ),
            new States.StateAndSingleResults<States.LexerState, Val>(
                new States.LexerState(),
                new Int(1)
            )
        );
        Assert.AreEqual(
            rule.Call(
                new States.LexerState(("int", "1"), ("str", "a"))
            ),
            new States.StateAndSingleResults<States.LexerState, Val>(
                new States.LexerState(("str", "a")),
                new Int(1)
            )
        );
    }
}