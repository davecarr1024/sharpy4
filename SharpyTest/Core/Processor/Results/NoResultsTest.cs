namespace Sharpy.Core.Processor.Results;

[TestClass]
public class NoResultsTest
{
    private record Result(int Value);

    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new NoResults<Result>().No(),
            new NoResults<Result>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<Result>>(() => new NoResults<Result>().Single());
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(new NoResults<Result>().Optional(), new OptionalResults<Result>());
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(new NoResults<Result>().Multiple(), new MultipleResults<Result>());
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(new NoResults<Result>().Named(), new NamedResults<Result>());
        Assert.AreEqual(new NoResults<Result>().Named("a"), new NamedResults<Result>());
    }

    [TestMethod]
    public void TestOr()
    {
        Assert.AreEqual(
            new NoResults<Result>() | new NoResults<Result>(),
            new NoResults<Result>()
        );
        Assert.AreEqual(
            new NoResults<Result>() | new SingleResults<Result>(new Result(1)),
            new SingleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new NoResults<Result>() | new OptionalResults<Result>(new Result(1)),
            new OptionalResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new NoResults<Result>() | new MultipleResults<Result>(new Result(1)),
            new MultipleResults<Result>(new Result(1))
        );
        Assert.AreEqual(
            new NoResults<Result>() | new NamedResults<Result>(),
            new NamedResults<Result>()
        );
    }
}