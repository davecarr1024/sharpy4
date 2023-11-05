namespace Sharpy.Core.Regex;

[TestClass]
public class ZeroOrMoreTest
{
    [TestMethod]
    public void TestCall()
    {
        Assert.AreEqual(
            new ZeroOrMore(new Literal('a')).Call(new State()),
            new StateAndResult(
                new State(),
                new Result()
            )
        );
        Assert.AreEqual(
            new ZeroOrMore(new Literal('a')).Call(new State("b")),
            new StateAndResult(
                new State("b"),
                new Result()
            )
        );
        Assert.AreEqual(
            new ZeroOrMore(new Literal('a')).Call(new State("a")),
            new StateAndResult(
                new State(),
                new Result("a")
            )
        );
        Assert.AreEqual(
            new ZeroOrMore(new Literal('a')).Call(new State("ab")),
            new StateAndResult(
                new State("b", new(0, 1)),
                new Result("a")
            )
        );
        Assert.AreEqual(
            new ZeroOrMore(new Literal('a')).Call(new State("aa")),
            new StateAndResult(
                new State(),
                new Result("aa")
            )
        );
        Assert.AreEqual(
            new ZeroOrMore(new Literal('a')).Call(new State("aab")),
            new StateAndResult(
                new State("b", new(0, 2)),
                new Result("aa")
            )
        );
    }
}