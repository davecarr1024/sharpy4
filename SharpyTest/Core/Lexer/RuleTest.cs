namespace Sharpy.Core.Lexer;

[TestClass]
public class RuleTest
{
    [TestMethod]
    public void TestCall()
    {
        Assert.AreEqual(
            new Rule("r", "a").Call("a"),
            new StateAndResult(
                new State(),
                new Result("r", "a")
            )
        );
        Assert.AreEqual(
            new Rule("r", "a").Call("ab"),
            new StateAndResult(
                new State("b", new(0, 1)),
                new Result("r", "a")
            )
        );
    }
}