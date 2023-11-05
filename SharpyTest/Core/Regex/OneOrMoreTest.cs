namespace Sharpy.Core.Regex;

[TestClass]
public class OneOrMoreTest
{
    [TestMethod]
    public void TestCall()
    {
        Assert.ThrowsException<Error>(
            () => new OneOrMore(new Literal('a')).Call(new State())
        );
        Assert.ThrowsException<Error>(
            () => new OneOrMore(new Literal('a')).Call(new State("b"))
        );
        Assert.AreEqual(
            new OneOrMore(new Literal('a')).Call(new State("a")),
            new StateAndResult(
                new State(),
                new Result("a")
            )
        );
        Assert.AreEqual(
            new OneOrMore(new Literal('a')).Call(new State("ab")),
            new StateAndResult(
                new State("b", new(0, 1)),
                new Result("a")
            )
        );
        Assert.AreEqual(
            new OneOrMore(new Literal('a')).Call(new State("aa")),
            new StateAndResult(
                new State(),
                new Result("aa")
            )
        );
        Assert.AreEqual(
            new OneOrMore(new Literal('a')).Call(new State("aab")),
            new StateAndResult(
                new State("b", new(0, 2)),
                new Result("aa")
            )
        );
    }
}