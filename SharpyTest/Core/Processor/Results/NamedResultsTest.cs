namespace Sharpy.Core.Processor.Results;

[TestClass]
public class NamedResultsTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new NamedResults<Result>().No(),
            new NoResults<Result>()
        );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1))).No(),
            new NoResults<Result>()
        );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2))).No(),
            new NoResults<Result>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<Result>>(() => new NamedResults<Result>().Single());
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1))).Single(),
            new SingleResults<Result>(new Result(1))
        );
        Assert.ThrowsException<Error<Result>>(() => new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2))).Single());
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new NamedResults<Result>().Optional(),
            new OptionalResults<Result>()
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1))).Optional(),
            new OptionalResults<Result>(new Result(1))
            );
        Assert.ThrowsException<Error<Result>>(() => new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2))).Optional());
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new NamedResults<Result>().Multiple(),
            new MultipleResults<Result>()
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1))).Multiple(),
            new MultipleResults<Result>(new Result(1))
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2))).Multiple(),
            new MultipleResults<Result>(new Result(1), new Result(2))
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new NamedResults<Result>().Named(),
            new NamedResults<Result>()
            );
        Assert.AreEqual(
            new NamedResults<Result>().Named("a"),
            new NamedResults<Result>()
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1))).Named(),
            new NamedResults<Result>(("a", new Result(1)))
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1))).Named("a"),
            new NamedResults<Result>(("a", new Result(1)))
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2))).Named(),
            new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2)))
            );
        Assert.AreEqual(
            new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2))).Named("a"),
            new NamedResults<Result>(("a", new Result(1)), ("b", new Result(2)))
            );
    }
}