using System.Collections.Immutable;

namespace Sharpy.Core.Regex;

[TestClass]
public class AndTest
{
    [TestMethod]
    public void TestCall()
    {
        And rule = new(new Literal('a'), new Literal('b'));
        Assert.ThrowsException<Error>(() => rule.Call(new State()));
        Assert.ThrowsException<Error>(() => rule.Call(new State("a")));
        Assert.ThrowsException<Error>(() => rule.Call(new State("b")));
        Assert.AreEqual(
            rule.Call(new State("ab")),
            new StateAndResult(
                new State(),
                new Result("ab")
            )
        );
        Assert.AreEqual(
            rule.Call(new State("abc")),
            new StateAndResult(
                new State("c", new(0, 2)),
                new Result("ab")
            )
        );
    }
}