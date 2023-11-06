namespace Sharpy.Core.Parser.Results;

[TestClass]
public class MultipleResultsTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new MultipleResults<Result>().No(),
            new NoResults<Result>()
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)).No(),
            new NoResults<Result>()
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1), new Result(2)).No(),
            new NoResults<Result>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<Result>>(() => new MultipleResults<Result>().Single());
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)).Single(),
            new SingleResults<Result>(new Result(1))
        );
        Assert.ThrowsException<Error<Result>>(() => new MultipleResults<Result>(new Result(1), new Result(2)).Single());
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new MultipleResults<Result>().Optional(),
            new OptionalResults<Result>()
            );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)).Optional(),
            new OptionalResults<Result>(new Result(1))
            );
        Assert.ThrowsException<Error<Result>>(() => new MultipleResults<Result>(new Result(1), new Result(2)).Optional());
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new MultipleResults<Result>().Multiple(),
            new MultipleResults<Result>()
            );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)).Multiple(),
            new MultipleResults<Result>(new Result(1))
            );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1), new Result(2)).Multiple(),
            new MultipleResults<Result>(new Result(1), new Result(2))
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new MultipleResults<Result>().Named(),
            new NamedResults<Result>()
            );
        Assert.AreEqual(
            new MultipleResults<Result>().Named("a"),
            new NamedResults<Result>()
            );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)).Named(),
            new NamedResults<Result>(("", new Result(1)))
            );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)).Named("a"),
            new NamedResults<Result>(("a", new Result(1)))
            );
        Assert.ThrowsException<Error<Result>>(() => new MultipleResults<Result>(new Result(1), new Result(2)).Named());
        Assert.ThrowsException<Error<Result>>(() => new MultipleResults<Result>(new Result(1), new Result(2)).Named("a"));
    }

    [TestMethod]
    public void TestOrNo()
    {
        Assert.AreEqual(
            new MultipleResults<Result>() | new NoResults<Result>(),
            new MultipleResults<Result>()
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new NoResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
    }

    [TestMethod]
    public void TestOrSingle()
    {
        Assert.AreEqual(
            new MultipleResults<Result>() | new SingleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(2))
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new SingleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrOptional()
    {
        Assert.AreEqual(
            new MultipleResults<Result>() | new OptionalResults<Result>(),
            new MultipleResults<Result>()
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new OptionalResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new MultipleResults<Result>() | new OptionalResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(2))
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new OptionalResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrMultiple()
    {
        Assert.AreEqual(
            new MultipleResults<Result>() | new MultipleResults<Result>(),
            new MultipleResults<Result>()
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new MultipleResults<Result>(),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new MultipleResults<Result>() | new MultipleResults<Result>(new Result(1)),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new MultipleResults<Result>(new Result(1)),
            new MultipleResults<Result>(new Result(1), new Result(1))
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new MultipleResults<Result>(new Result(2)),
            new MultipleResults<Result>(new Result(1), new Result(2))
        );
    }

    [TestMethod]
    public void TestOrNamed()
    {
        Assert.AreEqual(
            new MultipleResults<Result>() | new NamedResults<Result>(),
            new NamedResults<Result>()
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new NamedResults<Result>(),
            new NamedResults<Result>(("", new Result(1)))
        );
        Assert.AreEqual(
            new MultipleResults<Result>() | new NamedResults<Result>(("a", new Result(2))),
            new NamedResults<Result>(("a", new Result(2)))
        );
        Assert.AreEqual(
            new MultipleResults<Result>(new Result(1)) | new NamedResults<Result>(("a", new Result(2))),
            new NamedResults<Result>(("", new Result(1)), ("a", new Result(2)))
        );
    }
}