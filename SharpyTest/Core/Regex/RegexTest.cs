namespace Sharpy.Core.Regex;

[TestClass]
public class RegexTest
{
    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual(
            Regex.Load(""),
            new And()
        );
        Assert.AreEqual(
            Regex.Load("a"),
            new Literal('a')
        );
        Assert.AreEqual(
            Regex.Load("ab"),
            new And(new Literal('a'), new Literal('b'))
        );
    }
}