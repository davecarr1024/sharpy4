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

    [TestMethod]
    public void TestOrNo()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new NoResults<Result>(),
            new SingleResults<Result>(new Result(1))
        );
    }

    [TestMethod]
    public void TestOrSingle()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new SingleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrOptional()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new OptionalResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new OptionalResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrMultiple()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new MultipleResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new MultipleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrNamed()
    {
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new NamedResults<Result>(),
            new NamedResults<Result>(("", new Result(1)))
        );
        Assert.AreEqual(
            new SingleResults<Result>(new Result(1)) | new NamedResults<Result>(("a", new Result(2))),
            new NamedResults<Result>(("", new Result(1)), ("a", new Result(2)))
        );
    }
}