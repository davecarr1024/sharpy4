using System.Collections.Immutable;

namespace Sharpy.Core.Regex;

[TestClass]
public class TestLiteral
{
    [TestMethod]
    public void TestCall()
    {
        Assert.ThrowsException<Error>(() =>
            new Literal('a').Call(new State())
        );
        Assert.AreEqual(
            new Literal('a').Call(new State("a")),
            new StateAndResult(
                new State(),
                new Result("a")
            )
        );
        Assert.AreEqual(
            new Literal('a').Call(new State("ab")),
            new StateAndResult(
                new State("b", new Chars.Position(0, 1)),
                new Result("a")
            )
        );
    }
}