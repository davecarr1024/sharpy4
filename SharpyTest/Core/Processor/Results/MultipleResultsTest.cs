namespace Sharpy.Core.Processor.Results;

[TestClass]
public class MultipleResultsTest
{
    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new MultipleResults<int?>().No(),
            new NoResults<int?>()
        );
        Assert.AreEqual(
            new MultipleResults<int?>(1).No(),
            new NoResults<int?>()
        );
        Assert.AreEqual(
            new MultipleResults<int?>(1, 2).No(),
            new NoResults<int?>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<int?>>(() => new MultipleResults<int?>().Single());
        Assert.AreEqual(
            new MultipleResults<int?>(1).Single(),
            new SingleResults<int?>(1)
        );
        Assert.ThrowsException<Error<int?>>(() => new MultipleResults<int?>(1, 2).Single());
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new MultipleResults<int?>().Optional(),
            new OptionalResults<int?>()
            );
        Assert.AreEqual(
            new MultipleResults<int?>(1).Optional(),
            new OptionalResults<int?>(1)
            );
        Assert.ThrowsException<Error<int?>>(() => new MultipleResults<int?>(1, 2).Optional());
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new MultipleResults<int?>().Multiple(),
            new MultipleResults<int?>()
            );
        Assert.AreEqual(
            new MultipleResults<int?>(1).Multiple(),
            new MultipleResults<int?>(1)
            );
        Assert.AreEqual(
            new MultipleResults<int?>(1, 2).Multiple(),
            new MultipleResults<int?>(1, 2)
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new MultipleResults<int?>().Named(),
            new NamedResults<int?>()
            );
        Assert.AreEqual(
            new MultipleResults<int?>().Named("a"),
            new NamedResults<int?>()
            );
        Assert.AreEqual(
            new MultipleResults<int?>(1).Named(),
            new NamedResults<int?>(("", 1))
            );
        Assert.AreEqual(
            new MultipleResults<int?>(1).Named("a"),
            new NamedResults<int?>(("a", 1))
            );
        Assert.ThrowsException<Error<int?>>(() => new MultipleResults<int?>(1, 2).Named());
        Assert.ThrowsException<Error<int?>>(() => new MultipleResults<int?>(1, 2).Named("a"));
    }
}