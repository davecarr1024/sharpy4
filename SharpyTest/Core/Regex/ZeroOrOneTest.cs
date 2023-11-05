namespace Sharpy.Core.Regex;

[TestClass]
public class ZeroOrOneTest
{
    [TestMethod]
    public void TestCall()
    {
        Assert.AreEqual(
            new ZeroOrOne(new Literal('a')).Call(new State()),
            new StateAndResult(
                new State(),
                new Result()
            )
        );
        Assert.AreEqual(
            new ZeroOrOne(new Literal('a')).Call(new State("b")),
            new StateAndResult(
                new State("b"),
                new Result()
            )
        );
        Assert.AreEqual(
            new ZeroOrOne(new Literal('a')).Call(new State("a")),
            new StateAndResult(
                new State(),
                new Result("a")
            )
        );
        Assert.AreEqual(
            new ZeroOrOne(new Literal('a')).Call(new State("ab")),
            new StateAndResult(
                new State("b", new(0, 1)),
                new Result("a")
            )
        );
    }
}