namespace Sharpy.Core.Parser.Results;

[TestClass]
public class OptionalResultsTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new OptionalResults<Result>().No(),
            new NoResults<Result>()
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)).No(),
            new NoResults<Result>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<Result>>(() => new OptionalResults<Result>().Single());
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)).Single(),
            new SingleResults<Result>(new Result(1))
        );
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new OptionalResults<Result>().Optional(),
            new OptionalResults<Result>()
            );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)).Optional(),
            new OptionalResults<Result>(new Result(1))
            );
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new OptionalResults<Result>().Multiple(),
            new MultipleResults<Result>()
            );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)).Multiple(),
            new MultipleResults<Result>(new Result(1))
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new OptionalResults<Result>().Named(),
            new NamedResults<Result>()
            );
        Assert.AreEqual(
            new OptionalResults<Result>().Named("a"),
            new NamedResults<Result>()
            );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)).Named(),
            new NamedResults<Result>(("", new Result(1)))
            );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)).Named("a"),
            new NamedResults<Result>(("a", new Result(1)))
            );
    }

    [TestMethod]
    public void TestOrNo()
    {
        Assert.AreEqual(
            new OptionalResults<Result>() | new NoResults<Result>(),
            new OptionalResults<Result>()
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new NoResults<Result>(),
            new OptionalResults<Result>(new Result(1))
        );
    }

    [TestMethod]
    public void TestOrSingle()
    {
        Assert.AreEqual(
            new OptionalResults<Result>() | new SingleResults<Result>(new Result(1)),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new SingleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrOptional()
    {
        Assert.AreEqual(
            new OptionalResults<Result>() | new OptionalResults<Result>(),
            new MultipleResults<Result>()
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new OptionalResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new OptionalResults<Result>() | new OptionalResults<Result>(new Result(1)),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new OptionalResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrMultiple()
    {
        Assert.AreEqual(
            new OptionalResults<Result>() | new MultipleResults<Result>(),
            new MultipleResults<Result>()
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new MultipleResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new OptionalResults<Result>() | new MultipleResults<Result>(new Result(1)),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new MultipleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrNamed()
    {
        Assert.AreEqual(
            new OptionalResults<Result>() | new NamedResults<Result>(),
            new NamedResults<Result>()
        );
        Assert.AreEqual(
            new OptionalResults<Result>() | new NamedResults<Result>(("a", new Result(2))),
            new NamedResults<Result>(("a", new Result(2)))
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new NamedResults<Result>(),
            new NamedResults<Result>(("", new Result(1)))
        );
        Assert.AreEqual(
            new OptionalResults<Result>(new Result(1)) | new NamedResults<Result>(("a", new Result(2))),
            new NamedResults<Result>(("", new Result(1)), ("a", new Result(2)))
        );
    }
}