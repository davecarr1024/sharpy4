namespace Sharpy.Core.Processor.Results;

[TestClass]
public class SingleResultsTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)).No(),
            new NoResults<Result>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)).Single(),
            new SingleResults<Result>(new Result(1))
        );
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)).Optional(),
            new OptionalResults<Result>(new Result(1))
            );
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)).Multiple(),
            new MultipleResults<Result>(new Result(1))
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)).Named(),
            new NamedResults<Result>(("", new Result(1)))
            );
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)).Named("a"),
            new NamedResults<Result>(("a", new Result(1)))
            );
    }
}