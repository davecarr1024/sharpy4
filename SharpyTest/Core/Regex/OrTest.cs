namespace Sharpy.Core.Regex;

[TestClass]
public class OrTest
{
    [TestMethod]
    public void TestCall()
    {
        Or rule = new(new Literal('a'), new Literal('b'));
        Assert.ThrowsException<Error>(() => rule.Call(""));
        Assert.ThrowsException<Error>(() => rule.Call("c"));
        Assert.AreEqual(
            rule.Call("a"),
            new StateAndResult(
                new State(),
                new Result("a")
            )
        );
        Assert.AreEqual(
            rule.Call("b"),
            new StateAndResult(
                new State(),
                new Result("b")
            )
        );
        Assert.AreEqual(
            rule.Call("ac"),
            new StateAndResult(
                new State("c", new(0, 1)),
                new Result("a")
            )
        );
        Assert.AreEqual(
            rule.Call("bc"),
            new StateAndResult(
                new State("c", new(0, 1)),
                new Result("b")
            )
        );
    }
}