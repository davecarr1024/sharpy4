namespace Sharpy.Core.Regex;

[TestClass]
public class AnyTest
{
    [TestMethod]
    public void TestCall()
    {
        Assert.ThrowsException<Error>(() => new Any().Call(""));
        Assert.AreEqual<StateAndResult>(
            new Any().Call("a"),
            new StateAndResult(
                new State(new Chars.Stream()),
                new Result(new List<Chars.Char> { new('a', new()) })
            )
        );
    }
}